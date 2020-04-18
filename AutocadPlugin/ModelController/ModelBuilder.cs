using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using ParametersAndTools;

namespace ModelController
{
    /// <summary>
    ///     Класс для построения модели в документе
    /// </summary>
    public class ModelBuilder
    {
        /// <summary>
        ///     Параметры модели
        /// </summary>
        private readonly Parameters _parameters;

        /// <summary>
        ///     База данных документа
        /// </summary>
        private readonly Database _database;

        /// <summary>
        ///     Документ
        /// </summary>
        private readonly Document _document;

        public ModelBuilder(Document document, Parameters parameters)
        {
            _parameters = parameters;
            _database = document.Database;
            _document = document;
        }

        /// <summary>
        ///     Построить модель кровати
        /// </summary>
        public void BuildBed()
        {
            using (var docLock = _document.LockDocument())
            {
                BuildMainPart();
                BuildHeadboard();
                BuildLegs();
            }
        }

        /// <summary>
        ///     Построить основную часть
        /// </summary>
        private void BuildMainPart()
        {
            using (var transaction =
                _database.TransactionManager.StartTransaction())
            {
                var blockTableRecord = GetBlockTableRecord(transaction);
                using (var mainPartSolid3d = new Solid3d())
                {
                    mainPartSolid3d.CreateBox(
                        _parameters.ModelParameters[ParameterType.MainPartLength].Value,
                        _parameters.ModelParameters[ParameterType.MainPartWidth].Value,
                        _parameters.ModelParameters[ParameterType.MainPartHeight].Value);

                    blockTableRecord.AppendEntity(mainPartSolid3d);
                    transaction.AddNewlyCreatedDBObject(mainPartSolid3d, true);
                }

                transaction.Commit();
            }
        }

        /// <summary>
        ///     Построить ножки
        /// </summary>
        private void BuildLegs()
        {
            var leftLegDisplacement =
                new Point3d(
                    -_parameters.ModelParameters[ParameterType.MainPartLength].Value / 2 +
                    _parameters.ModelParameters[ParameterType.LegsDiameter].Value / 2,
                    _parameters.ModelParameters[ParameterType.MainPartWidth].Value / 2 -
                    _parameters.ModelParameters[ParameterType.LegsDiameter].Value / 2,
                    -_parameters.ModelParameters[ParameterType.LegsHeight].Value / 2 -
                    _parameters.ModelParameters[ParameterType.MainPartHeight].Value / 2) -
                Point3d.Origin;

            var rightLegDisplacement =
                new Point3d(
                    -_parameters.ModelParameters[ParameterType.MainPartLength].Value / 2 +
                    _parameters.ModelParameters[ParameterType.LegsDiameter].Value / 2,
                    -_parameters.ModelParameters[ParameterType.MainPartWidth].Value / 2 +
                    _parameters.ModelParameters[ParameterType.LegsDiameter].Value / 2,
                    -_parameters.ModelParameters[ParameterType.LegsHeight].Value / 2 -
                    _parameters.ModelParameters[ParameterType.MainPartHeight].Value / 2) -
                Point3d.Origin;

            using (var transaction =
                _database.TransactionManager.StartTransaction())
            {
                var blockTableRecord = GetBlockTableRecord(transaction);

                using (var leftLegSolid3d = new Solid3d())
                {
                    leftLegSolid3d.CreateFrustum(
                        _parameters.ModelParameters[ParameterType.LegsHeight].Value,
                        _parameters.ModelParameters[ParameterType.LegsDiameter].Value / 2,
                        _parameters.ModelParameters[ParameterType.LegsDiameter].Value / 2,
                        _parameters.ModelParameters[ParameterType.LegsDiameter].Value /
                        2);

                    leftLegSolid3d.TransformBy(
                        Matrix3d.Displacement(leftLegDisplacement));

                    blockTableRecord.AppendEntity(leftLegSolid3d);
                    transaction.AddNewlyCreatedDBObject(leftLegSolid3d, true);
                }

                using (var rightLegSolid3d = new Solid3d())
                {
                    rightLegSolid3d.CreateFrustum(
                        _parameters.ModelParameters[ParameterType.LegsHeight].Value,
                        _parameters.ModelParameters[ParameterType.LegsDiameter].Value / 2,
                        _parameters.ModelParameters[ParameterType.LegsDiameter].Value / 2,
                        _parameters.ModelParameters[ParameterType.LegsDiameter].Value /
                        2);

                    rightLegSolid3d.TransformBy(
                        Matrix3d.Displacement(rightLegDisplacement));

                    blockTableRecord.AppendEntity(rightLegSolid3d);
                    transaction.AddNewlyCreatedDBObject(rightLegSolid3d, true);
                }

                transaction.Commit();
            }
        }

        /// <summary>
        ///     Построить спинку
        /// </summary>
        private void BuildHeadboard()
        {
            var headboardDisplacement =
                new Point3d(
                    _parameters.ModelParameters[ParameterType.MainPartLength].Value / 2 +
                    _parameters.ModelParameters[ParameterType.HeadboardThickness]
                        .Value / 2, 0,
                    _parameters.ModelParameters[ParameterType.MainPartHeight].Value / 2) -
                Point3d.Origin;

            using (var transaction =
                _database.TransactionManager.StartTransaction())
            {
                var blockTableRecord = GetBlockTableRecord(transaction);

                using (var headboardSolid3d = new Solid3d())
                {
                    headboardSolid3d.CreateBox(
                        _parameters.ModelParameters[ParameterType.HeadboardThickness]
                            .Value,
                        _parameters.ModelParameters[ParameterType.MainPartWidth].Value,
                        _parameters.ModelParameters[ParameterType.HeadboardHeight].Value);

                    headboardSolid3d.TransformBy(
                        Matrix3d.Displacement(headboardDisplacement));

                    blockTableRecord.AppendEntity(headboardSolid3d);
                    transaction.AddNewlyCreatedDBObject(headboardSolid3d, true);
                }

                transaction.Commit();
            }
        }

        /// <summary>
        ///     Получить таблицу блоков транзакции
        /// </summary>
        /// <param name="transaction">Транзакция</param>
        /// <returns>BlockTableRecord для данной транзакции</returns>
        private BlockTableRecord GetBlockTableRecord(Transaction transaction)
        {
            var blockTable =
                transaction.GetObject(_database.BlockTableId, OpenMode.ForRead) as
                    BlockTable;

            return transaction.GetObject(blockTable[BlockTableRecord.ModelSpace],
                OpenMode.ForWrite) as BlockTableRecord;
        }
    }
}