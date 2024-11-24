namespace WEB.Models.Response
{
    public class ResponseModelConteudo
    {
        public int cdConteudo { get; set; }
        public string dsConteudo { get; set; }
        public string nmArquivo { get; set; }
        public string dsExtensao { get; set; }
        public byte[] arquivo { get; set; }
    }
}
