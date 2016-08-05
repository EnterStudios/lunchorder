﻿using System;
using System.Collections.Generic;

namespace Lunchorder.Domain.Dtos.Responses
{
    public class GetUserInfoResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public decimal Balance { get; set; }
        public UserProfile Profile { get; set; }
        public IEnumerable<UserBadge> Badges { get; set; }
        public IEnumerable<MenuEntryFavorite> Favorites { get; set; }
        public IEnumerable<LastOrder> Last5Orders { get; set; }
        public IEnumerable<string> Roles { get; set; }

        /// <summary>
        /// A new token for the user in case of user creation in our database.
        /// </summary>
        public string UserToken { get; set; }
    }
}
