namespace WEB.Models.Response {
    public class ResponseModelCertificado {
        public int cdCertificado { get; set; }
        public string? nmArquivo { get; set; }
        public string? dsExtensao { get; set; }
        public byte[]? arquivo { get; set; }
    }
}
