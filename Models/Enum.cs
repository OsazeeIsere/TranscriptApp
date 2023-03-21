namespace TranscriptApp.Models
{
    public class Enum
    {
        public enum TranscriptStatus
        {
            Pending,
            Awaiting_Approval,
            Approved,      
            Sent
        }
        public enum Title
        {
            Mr,
            Mrs,
            Ms,
            Dr,
            Prof
        }
        //Post Graduate Progress Report Ranking
        public enum Ranking
        {
            Pending,
            Satisfied,
            Partially_Satisfied,
            Not_Satisfied
        }
        public enum PgProgram
        {
            PGD,
            MSc,
            MPhil,
            MPhil_PhD,
            PhD
        }
       
    }
}
