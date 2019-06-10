using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Infrastructure.Tests
{
    public class Constants
    {
        #region Github API
        public const string API_GITHUB = "https://api.github.com/";
        public const string API_GISTS = "https://api.github.com/gists"; 
        #endregion

        #region Fake Online REST API:JSONPlaceholder(https://jsonplaceholder.typicode.com/)
        public const string FAKE_URL = "https://jsonplaceholder.typicode.com";
        public const string FAKE_COMMON_RESOURCE_POSTS = "/posts";
        public const string FAKE_COMMON_RESOURCE_COMMENTS = "/comments";
        public const string FAKE_COMMON_RESOURCE_ALBUMS = "/albums";
        public const string FAKE_COMMON_RESOURCE_PHOTOS = "/photos";
        public const string FAKE_COMMON_RESOURCE_TODOS = "/todos";
        public const string FAKE_COMMON_RESOURCE_USERS = "/users";
        #endregion
    }
}
