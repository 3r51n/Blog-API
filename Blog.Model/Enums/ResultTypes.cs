using System.ComponentModel.DataAnnotations;

namespace Blog.Model.Enums
{
    public enum ResultTypes
    {
        [Display(Name = "NONE")]
        None,

        [Display(Name = "SUCCESS")]
        Success,

        [Display(Name = "FAIL")]
        Fail,

        [Display(Name = "BATCH-OPERATION-COMPLETED")]
        BatchOperationCompleted
    }
}
