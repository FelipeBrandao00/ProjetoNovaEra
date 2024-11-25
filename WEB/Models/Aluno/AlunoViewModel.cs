using static WEB.Models.Shared.ListarPadraoViewModel;
using System.Net.Http.Headers;
using System.Text.Json;
using Application.Responses;

namespace WEB.Models.Aluno;

public class AlunoViewModel {
    public async Task<Response<ResponseModelTurmaAluno>> BuscarTurmaAtual(IConfiguration configuration, ResponseModelUsuario responseModelUsuario) {
        using (var client = new HttpClient()) {
            var baseUrl = configuration["BaseRequest"];
            var url = $"{baseUrl}/Aluno/GetAtualTurmaByUsuarioId/{responseModelUsuario.CdUsuario}";

            var token = configuration["JwtToken"];
            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try {
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                    return new Response<ResponseModelTurmaAluno> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                var responseBody = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var responseData = JsonSerializer.Deserialize<Response<ResponseModelTurmaAluno>>(responseBody, options);

                if (responseData == null || !responseData.IsSuccess)
                    return new Response<ResponseModelTurmaAluno> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                return responseData;
            }
            catch (Exception ex) {
                while (ex.InnerException != null) { ex = ex.InnerException; }
                return new Response<ResponseModelTurmaAluno> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
            }
        }
    }
    public async Task<Response<List<ResponseModelTurmaAluno>>> BuscarTodasAsTurmas(IConfiguration configuration, Guid cdUsuario) {
        using (var client = new HttpClient()) {
            var baseUrl = configuration["BaseRequest"];
            var url = $"{baseUrl}/Aluno/GetAllTurmasByUsuarioId/{cdUsuario}";

            var token = configuration["JwtToken"];
            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try {
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                    return new Response<List<ResponseModelTurmaAluno>> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                var responseBody = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var responseData = JsonSerializer.Deserialize<Response<List<ResponseModelTurmaAluno>>>(responseBody, options);

                if (responseData == null || !responseData.IsSuccess)
                    return new Response<List<ResponseModelTurmaAluno>> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                return responseData;
            } catch (Exception ex) {
                while (ex.InnerException != null) { ex = ex.InnerException; }
                return new Response<List<ResponseModelTurmaAluno>> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
            }
        }
    }

    public async Task<Response<List<ResponseModelUsuario>>> BuscarPorTurma(IConfiguration configuration, ResponseModelTurma ResponseModelTurma) {
        using (var client = new HttpClient()) {
            var baseUrl = configuration["BaseRequest"];
            var url = $"{baseUrl}/Aluno/GetAlunosByTurmaId/?turmaId={ResponseModelTurma.CdTurma}";

            var token = configuration["JwtToken"];
            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try {
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                    return new Response<List<ResponseModelUsuario>> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                var responseBody = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var responseData = JsonSerializer.Deserialize<Response<List<ResponseModelUsuario>>>(responseBody, options);

                if (responseData == null || !responseData.IsSuccess)
                    return new Response<List<ResponseModelUsuario>> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                return responseData;
            } catch (Exception ex) {
                while (ex.InnerException != null) { ex = ex.InnerException; }
                return new Response<List<ResponseModelUsuario>> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
            }
        }
    }
}