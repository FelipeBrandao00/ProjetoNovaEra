using Application.Responses;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using WEB.Models.Response;
using static WEB.Models.Shared.ListarPadraoViewModel;

namespace WEB.Models.CadastroConteudo {
    public class CadastroConteudoViewModel {

        public int CdAula { get; set; }
        public int CdTurma { get; set; }
        public int CdConteudo { get; set; }
        public string DsConteudo { get; set; }
        public byte[] DsArquivo { get; set; }

        public async Task<ResponseModelListaPadrao<ResponseModelConteudo>> Listar(IConfiguration configuration)
        {
            using (var client = new HttpClient())
            {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Conteudo/GetConteudosByAulaId/{CdAula}";

                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try
                {
                    var response = await client.GetAsync(url);
                    if (!response.IsSuccessStatusCode)
                        return new ResponseModelListaPadrao<ResponseModelConteudo> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<ResponseModelListaPadrao<ResponseModelConteudo>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return new ResponseModelListaPadrao<ResponseModelConteudo> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                    return responseData;
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null) { ex = ex.InnerException; }
                    return new ResponseModelListaPadrao<ResponseModelConteudo> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
                }
            }
        }

        public async Task<Response<ResponseModelConteudo>> Excluir(IConfiguration configuration)
        {
            using (var client = new HttpClient())
            {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Conteudo";
                var Body = new
                {
                    cdConteudo = CdConteudo,
                };

                //eu odeio minha vida...
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(url),
                    Content = new StringContent(JsonSerializer.Serialize(Body), Encoding.UTF8, "application/json")
                };

                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try
                {
                    var response = await client.SendAsync(request);
                    if (!response.IsSuccessStatusCode)
                        return new Response<ResponseModelConteudo> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<Response<ResponseModelConteudo>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return new Response<ResponseModelConteudo> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                    return responseData;
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null) { ex = ex.InnerException; }
                    return new Response<ResponseModelConteudo> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
                }
            }
        }

        /*
        public async Task<Response<ResponseModelConteudo>> Adicionar(IConfiguration configuration)
        {
            using (var client = new HttpClient())
            {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Conteudo?DsConteudo={DsConteudo}&CdAula={CdAula}&CdTurma={CdTurma}";

                var content = new StringContent(JsonSerializer.Serialize(DsArquivo), Encoding.UTF8, "application/json");

                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try
                {
                    var response = await client.PostAsync(url, content);
                    if (!response.IsSuccessStatusCode)
                        return new Response<ResponseModelConteudo> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<Response<ResponseModelConteudo>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return new Response<ResponseModelConteudo> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                    return responseData;
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null) { ex = ex.InnerException; }
                    return new Response<ResponseModelConteudo> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
                }
            }
        }
        */





        public async Task<Response<ResponseModelConteudo>> Adicionar(IConfiguration configuration)
        {
            using (var client = new HttpClient())
            {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Conteudo?DsConteudo={Uri.EscapeDataString(DsConteudo)}&CdAula={CdAula}&CdTurma={CdTurma}";

                // Cria o conteúdo multipart/form-data
                using (var content = new MultipartFormDataContent())
                {
                    // Adiciona o arquivo, se existir
                    if (DsArquivo != null && DsArquivo.Length > 0)
                    {
                        var fileContent = new ByteArrayContent(DsArquivo);
                        //fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                        //fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                        fileContent.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
                        content.Add(fileContent, "DsArquivo", "arquivo.pdf");
                    }

                    // Adiciona o token, se existir
                    var token = configuration["JwtToken"];
                    if (!string.IsNullOrEmpty(token))
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    try
                    {
                        // Envia a requisição POST
                        var response = await client.PostAsync(url, content);
                        if (!response.IsSuccessStatusCode)
                            return new Response<ResponseModelConteudo>
                            {
                                Data = null,
                                IsSuccess = false,
                                Message = "Erro no retorno da requisição."
                            };

                        // Processa a resposta da API
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                        var responseData = JsonSerializer.Deserialize<Response<ResponseModelConteudo>>(responseBody, options);

                        if (responseData == null || !responseData.IsSuccess)
                            return new Response<ResponseModelConteudo>
                            {
                                Data = null,
                                IsSuccess = false,
                                Message = "Erro no conteúdo retornado pela requisição."
                            };

                        return responseData;
                    }
                    catch (Exception ex)
                    {
                        while (ex.InnerException != null) { ex = ex.InnerException; }
                        return new Response<ResponseModelConteudo>
                        {
                            Data = null,
                            IsSuccess = false,
                            Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message
                        };
                    }
                }
            }
        }


    }
}
