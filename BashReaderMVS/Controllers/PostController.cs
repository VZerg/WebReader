using System.Collections.Generic;
using System;
using System.Web.Mvc;
using BashReaderMVS.Models;
using BashReader.Data;
using BashReader.Models;

namespace BashReaderMVS.Controllers
{
    public class PostController : Controller
    {
        private PostsRepository _repository = new PostsRepository();
        // GET: Post
        public ActionResult Index()
        {
            List<Models.PostViewModel> posts = new List<Models.PostViewModel>();
            foreach (BashReader.Models.Post post in _repository.GetAll())
            {
                posts.Add(new Models.PostViewModel
                {
                    PostId = post.PostId,
                    Rating = post.Rating,
                    Title = post.PostName,
                    Id = post.Id,
                    Description = post.PostText,
                    PublishDate = post.PublishDate,
                    ShortDescription = (post.PostText.Length > 50 ? (post.PostText.Remove(50, post.PostText.Length - 50) + "...") : post.PostText)
                });
            }
            return View(posts);
        }

        public ActionResult Details(Guid id)
        {
            Models.PostViewModel post = new Models.PostViewModel();
            post.Title = _repository.Get(id).PostName;
            post.Id = _repository.Get(id).Id;
            post.Description = _repository.Get(id).PostText;
            post.PublishDate = _repository.Get(id).PublishDate;
            return View(post);
        }

        public ActionResult Delete(Guid id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult CreateAll()
        {
            PageParser newPage = new PageParser();
            newPage.ParsePage();
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            PostViewModel post = new PostViewModel();
            post.Title = _repository.Get(id).PostName;
            post.Id = _repository.Get(id).Id;
            post.Description = _repository.Get(id).PostText;
            post.PublishDate = _repository.Get(id).PublishDate;
            post.Rating = _repository.Get(id).Rating;
            return View(post);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(PostViewModel changedPost)
        {
            Post newPost = _repository.Get(changedPost.Id);

            newPost.PostText = changedPost.Description;
            newPost.Rating = changedPost.Rating;
            newPost.PostName = changedPost.Title;
            _repository.Update(newPost, newPost.Id);

            return RedirectToAction("Index");
        }

    }
}