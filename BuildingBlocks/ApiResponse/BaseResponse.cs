using BuildingBlocks.Common.Constants;

namespace BuildingBlocks.ApiResponse;

public class BaseResponse<T>
{
    private int _code;

    public int Code
    {
        get => _code;
        set
        {
            _code = value;
            Msg = MessageConstant.GetMessage(value);
        }
    }

    public string Msg { get; set; }
    
    public string? MsgDetail { get; set; }
    
    public T Data { get; set; } = default!;
}

public class ModelsResponse<T>
{
    private int _code;

    public int Code
    {
        get => _code;
        set
        {
            _code = value;
            Msg = MessageConstant.GetMessage(value);
        }
    }

    public PagingMetadata Paging { get; set; }
    
    public string Msg { get; set; }
    
    public string? MsgDetail { get; set; }
    
    public List<T> Data { get; set; }
}

public class PagingMetadata
{
    public int Page { get; set; }
    
    public int Size { get; set; }
    
    public int Total { get; set; }
    
    public int TotalResult { get; set; }
}