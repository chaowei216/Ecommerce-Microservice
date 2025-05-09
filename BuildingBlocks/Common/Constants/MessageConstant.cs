﻿using Microsoft.AspNetCore.Http;

namespace BuildingBlocks.Common.Constants;

public static class MessageConstant
{
        public static string GetMessage(int code)
    {
        return code switch
        {
            #region Success

            StatusCodes.Status200OK => "OK",
            StatusCodes.Status201Created => "Created",
            StatusCodes.Status202Accepted => "Accepted",
            StatusCodes.Status203NonAuthoritative => "Non-Authoritative Information",
            StatusCodes.Status204NoContent => "No Content",
            StatusCodes.Status205ResetContent => "Reset Content",
            StatusCodes.Status206PartialContent => "Partial Content",
            StatusCodes.Status207MultiStatus => "Multi-Status",
            StatusCodes.Status208AlreadyReported => "Already Reported",
            StatusCodes.Status226IMUsed => "IM Used",

            #endregion

            #region Redirection

            StatusCodes.Status300MultipleChoices => "Multiple Choices",
            StatusCodes.Status301MovedPermanently => "Moved Permanently",
            StatusCodes.Status302Found => "Found",
            StatusCodes.Status303SeeOther => "See Other",
            StatusCodes.Status304NotModified => "Not Modified",
            StatusCodes.Status305UseProxy => "Use Proxy",
            StatusCodes.Status307TemporaryRedirect => "Temporary Redirect",
            StatusCodes.Status308PermanentRedirect => "Permanent Redirect",

            #endregion

            #region Client Errors

            StatusCodes.Status400BadRequest => "Bad Request",
            StatusCodes.Status401Unauthorized => "Unauthorized",
            StatusCodes.Status402PaymentRequired => "Payment Required",
            StatusCodes.Status403Forbidden => "Forbidden",
            StatusCodes.Status404NotFound => "Not Found",
            StatusCodes.Status405MethodNotAllowed => "Method Not Allowed",
            StatusCodes.Status406NotAcceptable => "Not Acceptable",
            StatusCodes.Status407ProxyAuthenticationRequired => "Proxy Authentication Required",
            StatusCodes.Status408RequestTimeout => "Request Timeout",
            StatusCodes.Status409Conflict => "Conflict",
            StatusCodes.Status410Gone => "Gone",
            StatusCodes.Status411LengthRequired => "Length Required",
            StatusCodes.Status412PreconditionFailed => "Precondition Failed",
            StatusCodes.Status413PayloadTooLarge => "Payload Too Large",
            StatusCodes.Status415UnsupportedMediaType => "Unsupported Media Type",
            StatusCodes.Status416RangeNotSatisfiable => "Range Not Satisfiable",
            StatusCodes.Status417ExpectationFailed => "Expectation Failed",
            StatusCodes.Status418ImATeapot => "I'm a teapot",
            StatusCodes.Status422UnprocessableEntity => "Unprocessable Entity",
            StatusCodes.Status423Locked => "Locked",
            StatusCodes.Status424FailedDependency => "Failed Dependency",
            StatusCodes.Status426UpgradeRequired => "Upgrade Required",
            StatusCodes.Status428PreconditionRequired => "Precondition Required",
            StatusCodes.Status429TooManyRequests => "Too Many Requests",
            StatusCodes.Status431RequestHeaderFieldsTooLarge => "Request Header Fields Too Large",
            StatusCodes.Status451UnavailableForLegalReasons => "Unavailable For Legal Reasons",

            #endregion

            #region Server Errors

            StatusCodes.Status500InternalServerError => "Internal Server Error",
            StatusCodes.Status501NotImplemented => "Not Implemented",
            StatusCodes.Status502BadGateway => "Bad Gateway",
            StatusCodes.Status503ServiceUnavailable => "Service Unavailable",
            StatusCodes.Status504GatewayTimeout => "Gateway Timeout",
            StatusCodes.Status505HttpVersionNotsupported => "HTTP Version Not Supported",
            StatusCodes.Status506VariantAlsoNegotiates => "Variant Also Negotiates",
            StatusCodes.Status507InsufficientStorage => "Insufficient Storage",
            StatusCodes.Status508LoopDetected => "Loop Detected",
            StatusCodes.Status510NotExtended => "Not Extended",
            StatusCodes.Status511NetworkAuthenticationRequired => "Network Authentication Required",

            #endregion

            _ => "Unknown Status Code"
        };
    }
}