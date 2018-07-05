using AutoMapper;
using HomeCinema.Data.Infrastructure;
using HomeCinema.Data.Repositories;
using HomeCinema.Entities;
using HomeCinema.Web.Infrastructure.Core;
using HomeCinema.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HomeCinema.Web.Controllers
{
    [RoutePrefix("api/profileuser")]
    public class ProfileUserController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<ProfileUser> _profileUserRepository;

        public ProfileUserController(IEntityBaseRepository<ProfileUser> profileUserRepository,
           IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
           : base(_errorsRepository, _unitOfWork)
        {
            _profileUserRepository = profileUserRepository;
        }

        [AllowAnonymous]
        [Route("get/{userId:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int userId)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var profileUser = _profileUserRepository.GetSingle(1);
                var profileUsersVM = Mapper.Map<ProfileUser, ProfileUserViewModel>(profileUser);
                response = request.CreateResponse<ProfileUserViewModel>(HttpStatusCode.OK, profileUsersVM);

                return response;
            });
        }
        [AllowAnonymous]
        [Route("{page:int=0}/{pageSize=3}/{filter?}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int? page, int? pageSize, string filter = null)
        {
            int currentPage = page.Value;
            int currentPageSize = pageSize.Value;

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                List<ProfileUser> profileUsers = null;
                int totalProfileUser = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    profileUsers = _profileUserRepository
                        .FindBy(m => m.Description.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalProfileUser = _profileUserRepository
                        .FindBy(m => m.Title.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .Count();
                }
                else
                {
                    profileUsers = _profileUserRepository
                        .GetAll()
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalProfileUser = _profileUserRepository.GetAll().Count();
                }

                IEnumerable<ProfileUserViewModel> profileUserVM = Mapper.Map<IEnumerable<ProfileUser>, IEnumerable<ProfileUserViewModel>>(profileUsers);

                PaginationSet<ProfileUserViewModel> pagedSet = new PaginationSet<ProfileUserViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalProfileUser,
                    TotalPages = (int)Math.Ceiling((decimal)totalProfileUser / currentPageSize),
                    Items = profileUserVM
                };

                response = request.CreateResponse<PaginationSet<ProfileUserViewModel>>(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }


    }
}