using DRMusicRest.Managers;
using DRMusicRest.Model;

namespace DRMusikRestTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetAll()
        {
            //Arrange
            RecordsManager _manager = new RecordsManager();
            int expectedResult = 3;

            //Act 
            List<Record> localRecordList = new List<Record>();
            localRecordList = _manager.GetAll(null);

            //Assert

            Assert.AreEqual(expectedResult, localRecordList.Count);
        }

        [TestMethod]
        public void TestGetAllFilter()
        {
            //Arrange
            RecordsManager _manager = new RecordsManager();
            int expectedResult1 = 1;
            //Act
            List<Record> localRecordList = new List<Record>();
            localRecordList = _manager.GetAll("Go");

            //Assert

            Assert.AreEqual(expectedResult1, localRecordList.Count);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            //Arrange
            RecordsManager _manager = new RecordsManager();
            string expectedResult = "Gorilaz";

            //Act
            var record = _manager.GetById(3);

            //Assert
            Assert.AreEqual(expectedResult, record.Title);
        }

        [TestMethod]
        public void GetInvalidIdTest()
        {
            //Arrange
            RecordsManager _manager = new RecordsManager();

            //Act
            var record = _manager.GetById(4);

            //Assert
            Assert.IsNull(record);
        }

        [TestMethod]
        public void AddRecordTest()
        {
            //Arrange
            RecordsManager _manager = new RecordsManager();
            int expectedResult = 4;
            Record record = new Record { Title = "Går og glor på vinduer", Artist = "Basim", Duration = 3600, PublicationYear = 2014 };

            //Act
            var recordList = _manager.GetAll(null);
            List<Record> localRecordList = new List<Record>();
            localRecordList = _manager.GetAll(null);
            localRecordList.Add(record);


            //Assert
            Assert.AreEqual(expectedResult, localRecordList.Count);



        }
        //[TestMethod]
        //public void AddRecordFilterTest()
        //{

        //    //Arrange
        //    RecordsManager _manager = new RecordsManager();
        //    int expectedResult = 1;
        //    Record record = new Record { Title = "KLAMFYR", Artist = "Basim", Duration = 3600, PublicationYear = 2014 };
        //    //Act
        //    var recordList = _manager.GetAll(null);
        //    recordList.Add(record);
        //    //recordList = _manager.GetAll("K");

        //    //Assert
        //    Assert.AreEqual(expectedResult, recordList.Count);

        //}

        [TestMethod]
        public void DeleteTest()
        {
            //Arrange
            RecordsManager _manager = new RecordsManager();
            int expectedResult = 3;
            Record record = new Record { Title = "Blood sugar sex magik", Artist = "Red Hot Chili Peppers", Duration = 4500, PublicationYear = 1991 };

            //Act
            var recordList = _manager.GetAll(null);
            List<Record> localRecordList = new List<Record>();
            localRecordList = _manager.GetAll(null);
            localRecordList.Add(record);


            localRecordList = recordList.ToList();
            _manager.Delete(3);

            //Assert
            Assert.AreEqual(expectedResult, localRecordList.Count);
        }
        [TestMethod]
        public void UpdateTest()
        {
            //Arrange
            RecordsManager _manager = new RecordsManager();
            string expectedArtist = "Basim";
            Record update = new Record { Title = "Går og glor på vinduer", Artist = "Basim", Duration = 3600, PublicationYear = 2014 };

            //Act
            var record = _manager.Update(1, update);

            //Assert
            Assert.AreEqual(expectedArtist, record.Artist);
        }
    }
}