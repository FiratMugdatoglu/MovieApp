using Microsoft.AspNetCore.SignalR;
using MovieApp.Web.Entity;
using MovieApp.Web.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MovieApp.Web.Data
{
	public class MovieRepository
	{
		private static readonly List<Movie> _movies = null;

		static MovieRepository()
		{
			_movies = new List<Movie>()
			{

				 new Movie {MovieId=1, Title = "Jiu Jitsu",Description="Every six years,an ancient order of jiu-jitsu",Director="Dimitri Logothetis",Players=new string[] {"Nicolas Cage ","Alain Moussi"},ImageUrl="1.jpg",GenreId=1},
				new Movie {MovieId=2, Title = "Fatman",Description="açıklama 2",Director="Yönetmen 2",Players=new string[] {"oyuncu 3","oyuncu 4"},ImageUrl="2.jpg",GenreId=1},
				new Movie {MovieId=3, Title = "The Dalton Gang",Description="açıklama 3",Director="Yönetmen 3",Players=new string[] {"oyuncu 5","oyuncu 6"},ImageUrl="3.jpg",GenreId=3},
				 new Movie {MovieId=4, Title = "Tenet",Description="açıklama 4",Director="Yönetmen 4",Players=new string[] {"oyuncu 7","oyuncu 8"},ImageUrl="1.jpg",GenreId=3},
				new Movie {MovieId=5, Title = "The Craft: Legacy",Description="açıklama 5",Director="Yönetmen 5",Players=new string[] {"oyuncu 9","oyuncu 10"},ImageUrl="2.jpg",GenreId=3},
				new Movie {MovieId=6, Title = "Hard Kill",Description="açıklama 6",Director="Yönetmen 6",Players=new string[] {"oyuncu 11","oyuncu 12"},ImageUrl="3.jpg",GenreId=4}



			};


		}


		public static List<Movie> Movies{

			get{
				return _movies;
			}
		
		
		}

		public static void Add(Movie movie)
		{
			movie.MovieId = _movies.Count() + 1;
			_movies.Add(movie);
		}


		public static Movie GetById(int id)
		{
			return _movies.FirstOrDefault(m => m.MovieId == id);
		}


		public static void Edit(Movie m) {
		
		foreach(var movie in _movies)
			{

				if(movie.MovieId == m.MovieId)
				{
					movie.Title = m.Title;
					movie.Description = m.Description;	
					movie.Director = m.Director;
				    movie.ImageUrl = m.ImageUrl;
					movie.GenreId = m.GenreId;
					break;
				}


			}

		}



		public static void Delete(int MovieId) {
		
		
		var movie = GetById(MovieId);

			if(movie != null)
			{

				_movies.Remove(movie);
			}
		
		
		}


	}
}
