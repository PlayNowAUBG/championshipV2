using ChampionshipMvc3.Models.Interfaces;
using ChampionshipMvc3.Models.Repositories;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChampionshipMvc3.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<IPlayfieldRepository>().To<PlayfieldRepository>();
            ninjectKernel.Bind<IPlayfieldOwnerRepository>().To<PlayfieldOwnerRepository>();
            ninjectKernel.Bind<ITennisPlayfieldOwnerRepository>().To<TennisPlayfieldOwnerRepository>();
            ninjectKernel.Bind<ITennisPlayfieldRepository>().To<TennisPlayfieldRepository>();
            ninjectKernel.Bind<IReservationRepository>().To<ReservationRepository>();
            ninjectKernel.Bind<IPictureRepository>().To<PictureRepository>();
        }
    }
}