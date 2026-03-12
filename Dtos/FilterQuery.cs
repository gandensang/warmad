namespace Dtos;

public class FilterQuery
{
    public string SortLabel { get; set; } = "UpdateAt";
    public string SortDirection { get; set; } = "DESC"; //descending,ascending
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string Keyword { get; set; } = "";
    public string ColumnField { get; set; } = "";
}