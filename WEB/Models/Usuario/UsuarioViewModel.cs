using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Application.Responses;

namespace WEB.Models.Usuario;

public class UsuarioViewModel
{
    public string DsCpf { get; set; } = string.Empty;

    public async Task<Response<ResponseModelUsuario>> BuscarInfo(IConfiguration configuration)
    {
        using (var client = new HttpClient())
        {
            var baseUrl = configuration["BaseRequest"];
            var url = $"{baseUrl}/Usuario/{DsCpf}";

            var token = configuration["JwtToken"];
            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                    return new Response<ResponseModelUsuario> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                var responseBody = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var responseData = JsonSerializer.Deserialize<Response<ResponseModelUsuario>>(responseBody, options);

                if (responseData == null || !responseData.IsSuccess)
                    return new Response<ResponseModelUsuario> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                return responseData;
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null) { ex = ex.InnerException; }
                return new Response<ResponseModelUsuario> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
            }
        }
    }

    public async Task<Response<ResponseModelUsuario>> AtualizarInfo(IConfiguration configuration, ResponseModelUsuario responseModelUsuario)
    {
        using (var client = new HttpClient())
        {
            var baseUrl = configuration["BaseRequest"];
            var url = $"{baseUrl}/Usuario/{responseModelUsuario.CdUsuario}";

            var content = new StringContent(JsonSerializer.Serialize(responseModelUsuario), Encoding.UTF8, "application/json");

            var token = configuration["JwtToken"];
            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                var response = await client.PutAsync(url, content);
                if (!response.IsSuccessStatusCode)
                    return new Response<ResponseModelUsuario> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                var responseBody = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var responseData = JsonSerializer.Deserialize<Response<ResponseModelUsuario>>(responseBody, options);

                if (responseData == null || !responseData.IsSuccess)
                    return new Response<ResponseModelUsuario> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                return responseData;
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null) { ex = ex.InnerException; }
                return new Response<ResponseModelUsuario> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
            }
        }
    }

    public async Task<Response<ResponseModelUsuario>> Adicionar(IConfiguration configuration, ResponseModelUsuario responseModelUsuario)
    {
        using (var client = new HttpClient())
        {
            var baseUrl = configuration["BaseRequest"];
            var url = $"{baseUrl}/Usuario";
            var Body = new
            {
                nmUsuario = responseModelUsuario.NmUsuario,
                dsEmail = responseModelUsuario.DsEmail,
                dsSenha = "CLj6QBTMn7/ypWBsDLPR2JMtyIs=",
                dsCpf = responseModelUsuario.DsCpf,
                dsGenero = responseModelUsuario.DsGenero,
                dtNascimento = responseModelUsuario.DtNascimento,
                icHabilitadoTurma = responseModelUsuario.IcHabilitadoTurma,
                dsFoto = "",
                dsTelefone = responseModelUsuario.DsTelefone
            };
            var content = new StringContent(JsonSerializer.Serialize(Body), Encoding.UTF8, "application/json");

            var token = configuration["JwtToken"];
            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                var response = await client.PostAsync(url, content);
                if (!response.IsSuccessStatusCode)
                    return new Response<ResponseModelUsuario> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                var responseBody = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var responseData = JsonSerializer.Deserialize<Response<ResponseModelUsuario>>(responseBody, options);

                if (responseData == null || !responseData.IsSuccess)
                    return new Response<ResponseModelUsuario> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                return responseData;
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null) { ex = ex.InnerException; }
                return new Response<ResponseModelUsuario> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
            }
        }
    }

}
