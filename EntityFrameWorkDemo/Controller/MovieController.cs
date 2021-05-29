using EntityFrameWorkDemo.Filters;
using EntityFrameWorkDemo.Model;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EntityFrameWorkDemo.Controller
{
   [EnableCors]
    public class MovieController : ApiController
    {
        DBMovieEntities1 db =new DBMovieEntities1();
       
        [Auth]    
        public IHttpActionResult PostData(Tbl_Movie_Master movie)
        {
            try
            {
                if (movie != null)
                {
                    db.Tbl_Movie_Master.Add(movie);
                    db.SaveChanges();
                    return Ok("Data is Inserted..!!!");
                }
                else
                {
                    return BadRequest("Provide Proper Data..!!");
                }
            }
            catch(Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Enter Proper Data");
            }
        }

        public IHttpActionResult GetAllData()
        {
            try
            {
                List<Tbl_Movie_Master> Data = db.Tbl_Movie_Master.ToList();
                if(Data.Count>0)
                {
                    return Content(HttpStatusCode.OK, Data);
                }
                else
                {
                    return Content(HttpStatusCode.NoContent, "No DATA FOUND");
                }

            }
            catch
            {
                return Content(HttpStatusCode.NoContent, "PLEASE TRY AGAIN..!!");
            }
        }
        public IHttpActionResult GetByID(int movie_id)
        {
            try
            {
   
               Tbl_Movie_Master movie= db.Tbl_Movie_Master.Find(movie_id);
                if (movie != null)
                {

                    return Content(HttpStatusCode.OK, movie);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "No DATA FOUND To this id "+movie_id);
                }

            }
            catch
            {
                return Content(HttpStatusCode.NoContent, "PLEASE TRY AGAIN..!!");
            }
        }
        [Auth]
        public IHttpActionResult UpdateData(int movie_id,Tbl_Movie_Master movie)
        {
            try
            {
                Tbl_Movie_Master movie1 = db.Tbl_Movie_Master.Find(movie_id);
              
                if (movie1 != null)
                {
                    movie1.Movie_name = movie.Movie_name;
                    movie1.Movie_cast = movie.Movie_cast;
                    db.SaveChanges();
                    return Content(HttpStatusCode.OK, "Data Updated Succesfully..!!");
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "No DATA FOUND To this id " + movie_id);
                }

            }
            catch
            {
                return Content(HttpStatusCode.NoContent, "PLEASE TRY AGAIN..!!");
            }
        }
        [Auth]
        public IHttpActionResult Delete(int movie_id)
        {
            try
            {
                Tbl_Movie_Master movie1 = db.Tbl_Movie_Master.Find(movie_id);
               
                if (movie1 != null)
                {
                    db.Tbl_Movie_Master.Remove(movie1);
                    db.SaveChanges();
                    return Content(HttpStatusCode.OK, "Data Deleted Succesfully..!!");
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "No DATA FOUND To this id " + movie_id);
                }

            }
            catch
            {
                return Content(HttpStatusCode.NoContent, "PLEASE TRY AGAIN..!!");
            }
        }
    }
}
