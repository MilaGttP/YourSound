
namespace YourSound
{
    public class Recent
    {
        public int ID { get; set; }
        public int AccountID { get; set; }
        public int SongID { get; set; }

        public virtual Song Song { get; set; }
        public virtual Account Account { get; set; }

        public Recent()
        {
            ID = 0;
            AccountID = 0;
            SongID = 0;
            Song = new Song();
            Account = new Account();
        }
    }
}
