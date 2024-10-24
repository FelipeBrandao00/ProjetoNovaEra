﻿using static WEB.Models.EsqueciSenha.EsqueciSenhaViewModel;
using System.Text.Json;
using System.Text;
using System.Text.Json.Serialization;
using Application.Responses;
using System.ComponentModel.DataAnnotations;

namespace WEB.Models.Shared;

public abstract class ListarPadraoViewModel
{
    public abstract string TipoItem { get; set; }
    public List<ItemListaPadrao>? ItensLista { get; set; }
    public int PaginaAtual { get; set; } = 1;
    public int PaginaTotal { get; set; } = 1;
    public int TamanhoPagina { get; set; } = 9;
    public int TotalItens { get; set; } = 0;
    public string Busca { get; set; } = String.Empty;

    public virtual async Task<bool> GerarLista(IConfiguration configuration)
    {
        return false;
    }

    public class ItemListaPadrao
    {
        public required string Id { get; set; }
        public required string Text { get; set; }
    }

    public class ResponseModelListaPadrao<TData> : Response<List<TData>?>
    {
        public int currentPage { get; set; }
        public int totalCount { get; set; }
        public int pageSize { get; set; }
        public int totalPages { get; set; }
    }
}
