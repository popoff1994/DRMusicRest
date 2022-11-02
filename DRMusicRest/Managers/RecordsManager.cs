using DRMusicRest.Model;

namespace DRMusicRest.Managers
{
    public class RecordsManager
    {
        public static int _nextId =1;
        private static readonly List<Record> Records = new List<Record>
        {
            new Record(id: _nextId++, title:"Smash Hit from Aberdeen", artist:"Malk De koijn", duration:4080, publicationYear:1998),
            new Record(id: _nextId++, title:"50 års pletskud", artist:"Birthe Kjær", duration:7200, publicationYear:2018),
            new Record(id: _nextId++, title:"Gorilaz", artist:"Gorilaz", duration:5500, publicationYear:2001),
        };

        //private static readonly List<Record> Records = new List<Record>
        //{
        //    new Record{Id = _nextId++, Title="Smash Hit from Aberdeen", Artist="Malk De koijn", Duration=4080, PublicationYear=1998},
        //    new Record{Title="50 års pletskud", Artist="Birthe Kjær", Duration=7200, PublicationYear=2018},
        //    new Record{Title="Gorilaz", Artist="Gorilaz", Duration=5500, PublicationYear=2001}
        //};

        public List<Record> GetAll(string ?title)
        {
            List<Record> records = new List<Record>(Records);
            if (title != null)
            {
                records = records.FindAll(records => records.Title != null && records.Title.StartsWith(title));
            }
            else if(title == null)
            {
                return records;
            }
            return records;
        }
        public Record GetById(int id)
        {
            return Records.Find(record => record.Id == id);
        }

        public Record Add(Record newRecord)
        {
            Records.Add(newRecord);
            return newRecord;
        }

        public Record Delete(int id)
        {
            Record record = Records.Find(records1 => records1.Id == id);
            if (record == null) return null;
            Records.Remove(record);
            return record;
        }

        public Record Update(int id, Record update)
        {
            Record? record = Records.Find(records1 => records1.Id == id);
            if (record == null) return null;
            record.Title = update.Title;
            record.Artist = update.Artist;
            record.Duration = update.Duration;
            record.PublicationYear = update.PublicationYear;
            return record;
        }
    }
}
