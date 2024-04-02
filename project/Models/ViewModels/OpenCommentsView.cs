using project.Model;
using project.Model.ViewModel;

namespace project.Model.ViewModel;

public class OpenCommentsView
{
    public int pageNumber { get; set; } = 1;
    public int pastPagesNumber { get; set; } = 0;
    public int nextPagesNumber { get; set; } = 0;
    public List<CommentView> commentsToView { get; set; } = new List<CommentView>();
}
