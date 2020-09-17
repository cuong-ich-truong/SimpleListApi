using System.Collections.Generic;

namespace SimpleListApi.Models
{
  public class ServiceResponse<T>
  {
    public T Data { get; set; }

    public bool Success { get; set; } = true;

    public string Message { get; set; } = "";

    public List<ServiceError> Errors { get; set; } = new List<ServiceError>();
  }
}