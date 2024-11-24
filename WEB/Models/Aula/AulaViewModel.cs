using Application.Responses;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using WEB.Models.Response;

namespace WEB.Models.Aula
{
    public class AulaViewModel
    {

        public int CdAula { get; set; }

        public async Task<Response<List<ResponseModelAula>>> BuscarPorTurma(IConfiguration configuration, ResponseModelTurma ResponseModelTurma, bool? icChamada = null, bool? icConteudo = null)
        {
            using (var client = new HttpClient())
            {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Aula/GetAulasByTurmaId/{ResponseModelTurma.CdTurma}";

                if (icChamada != null) {
                    url += $"?icChamada={icChamada.ToString().ToLower()}";
                }

                if (icConteudo != null)
                {
                    url += $"?icConteudo={icConteudo.ToString().ToLower()}";
                }

                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try
                {
                    var response = await client.GetAsync(url);
                    if (!response.IsSuccessStatusCode)
                        return new Response<List<ResponseModelAula>> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<Response<List<ResponseModelAula>>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return new Response<List<ResponseModelAula>> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                    return responseData;
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null) { ex = ex.InnerException; }
                    return new Response<List<ResponseModelAula>> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
                }
            }
        }
        public async Task<Response<ResponseModelAula>> BuscarInfo(IConfiguration configuration)
        {
            using (var client = new HttpClient())
            {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Aula/GetAulaById/{CdAula}";

                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try
                {
                    var response = await client.GetAsync(url);
                    if (!response.IsSuccessStatusCode)
                        return new Response<ResponseModelAula> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<Response<ResponseModelAula>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return new Response<ResponseModelAula> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                    return responseData;
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null) { ex = ex.InnerException; }
                    return new Response<ResponseModelAula> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
                }
            }
        }
        public async Task<Response<ResponseModelAula>> Adicionar(IConfiguration configuration, ResponseModelAula ResponseModelAula)
        {
            using (var client = new HttpClient())
            {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Aula";
                var Body = new {
                    dtAula = DateTime.Now,
                    nmAula = ResponseModelAula.nmAula,
                    dsAula = ResponseModelAula.dsAula,
                    cdTurma = ResponseModelAula.cdTurma
                };
                var content = new StringContent(JsonSerializer.Serialize(Body), Encoding.UTF8, "application/json");

                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try
                {
                    var response = await client.PostAsync(url, content);
                    if (!response.IsSuccessStatusCode)
                        return new Response<ResponseModelAula> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<Response<ResponseModelAula>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return new Response<ResponseModelAula> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                    return responseData;
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null) { ex = ex.InnerException; }
                    return new Response<ResponseModelAula> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
                }
            }
        }
        public async Task<Response<ResponseModelAula>> AtualizarInfo(IConfiguration configuration, ResponseModelAula ResponseModelAula)
        {
            using (var client = new HttpClient())
            {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Aula/{ResponseModelAula.cdAula}";
                var Body = new {
                    cdAula = ResponseModelAula.cdAula,
                    dtAula = ResponseModelAula.dtAula,
                    nmAula = ResponseModelAula.nmAula,
                    dsAula = ResponseModelAula.dsAula
                };
                var content = new StringContent(JsonSerializer.Serialize(ResponseModelAula), Encoding.UTF8, "application/json");

                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try
                {
                    var response = await client.PutAsync(url, content);
                    if (!response.IsSuccessStatusCode)
                        return new Response<ResponseModelAula> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<Response<ResponseModelAula>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return new Response<ResponseModelAula> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                    return responseData;
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null) { ex = ex.InnerException; }
                    return new Response<ResponseModelAula> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
                }
            }
        }
        public async Task<Response<ResponseModelAula>> Excluir(IConfiguration configuration, ResponseModelAula ResponseModelAula)
        {
            using (var client = new HttpClient())
            {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Aula";
                var Body = new
                {
                    CdAula = ResponseModelAula.cdAula,
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
                        return new Response<ResponseModelAula> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<Response<ResponseModelAula>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return new Response<ResponseModelAula> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                    return responseData;
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null) { ex = ex.InnerException; }
                    return new Response<ResponseModelAula> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
                }
            }
        }

    }
}
