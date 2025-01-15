using ArticleViewer.Models;
using ArticleViewer.Services;

namespace ArticleViewer.State
{
    public class ArticleState
    {
        public List<Article> Articles { get; private set; } = new List<Article>();
        public bool IsLoading { get; private set; } = false;
        public bool HasError { get; private set; } = false;
        public string ErrorMessage { get; private set; } = string.Empty;

        public event Action OnChange;

        public async Task LoadArticlesAsync(ArticleService articleService)
        {
            IsLoading = true;
            HasError = false;
            ErrorMessage = string.Empty;
            NotifyStateChanged();

            try
            {
                Articles = await articleService.GetArticlesAsync();
            }
            catch (Exception ex)
            {
                HasError = true;
                ErrorMessage = ex.Message;
            }
            finally
            {
                IsLoading = false;
                NotifyStateChanged();
            }
        }

        public async Task LoadArticleByIdAsync(int id, ArticleService articleService)
        {
            IsLoading = true;
            HasError = false;
            ErrorMessage = string.Empty;
            NotifyStateChanged();

            try
            {
                var article = await articleService.GetArticleByIdAsync(id);
                Articles = new List<Article> { article };
            }
            catch (Exception ex)
            {
                HasError = true;
                ErrorMessage = ex.Message;
            }
            finally
            {
                IsLoading = false;
                NotifyStateChanged();
            }
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
