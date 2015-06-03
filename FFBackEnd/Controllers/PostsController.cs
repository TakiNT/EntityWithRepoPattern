using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FFRepository;
using System.Web.Mvc;
using FFBackEnd.Models;

namespace FFBackEnd.Controllers
{
    public class PostsController : ApiController
    {
        private IUnitOfWork uow = null;
        private PostRepository repo = null;
        private PostJsonModels viewModel; 

        public PostsController()
        {
            uow = new UnitOfWork();
            repo = new PostRepository(uow);
            viewModel = new PostJsonModels();

            GetData2Models();
        }

        private void GetData2Models()
        {
            IEnumerable<Post> listPost = repo.GetAll();

            foreach (Post p in listPost)
            {
                PostJsonModels jm = new PostJsonModels();

                if (p.pavailable > 0)
                {
                    jm.MapData2Model(p);
                    jm.ListPost = null;

                    viewModel.ListPost.Add(jm);
                }
            }
        }
        
        // GET: Posts/GetPosts
        public List<PostJsonModels> GetPosts()
        {
            return viewModel.ListPost;
        }

        // GET: Posts/GetPost/5
        [ResponseType(typeof(PostJsonModels))]
        public IHttpActionResult GetPost(int id)
        {
            Post post = repo.Single(id);

            if (post == null)
            {
                return NotFound();
            }

            PostJsonModels jm = new PostJsonModels();
            jm.MapData2Model(post);
            jm.ListPost = null;

            return Ok(jm);
        }

        //// PUT: api/Posts/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutPost(int id, Post post)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != post.pid)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(post).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PostExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Posts
        //[ResponseType(typeof(Post))]
        //public IHttpActionResult PostPost(Post post)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Posts.Add(post);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = post.pid }, post);
        //}

        //// DELETE: api/Posts/5
        //[ResponseType(typeof(Post))]
        //public IHttpActionResult DeletePost(int id)
        //{
        //    return Ok(null);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool PostExists(int id)
        //{
        //    return db.Posts.Count(e => e.pid == id) > 0;
        //}
    }
}