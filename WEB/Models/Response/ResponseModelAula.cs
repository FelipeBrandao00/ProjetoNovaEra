namespace WEB.Models.Response
{
    public class ResponseModelAula
    {
        public int cdAula { get; set; }
        public DateTime dtAula { get; set; }
        public string dsAula { get; set; }
        public string nmAula { get; set; }
        public bool? isChamada { get; set; }
        public int? qtPresencas { get; set; }
        public int? qtArquivos { get; set; }
        public int cdTurma { get; set; }
    }
}
