namespace pr0gramm.WebApi.Models.Request {
  public class CaptchaRequest : BaseApiRequest {
    public CaptchaRequest() 
      : base("https", Constants.Pr0gramDomain, "/api/user/captcha") {
    }
  }
}
