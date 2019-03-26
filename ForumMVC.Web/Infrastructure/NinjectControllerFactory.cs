using System;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;
using Ninject;
using ForumMVC.BLL.Interfaces;
using System.Collections.Generic;
using ForumMVC.BLL.DTO;
using System.Linq;
using ForumMVC.BLL.Service;

namespace ForumMVC.Web.Infrastructure
{
    // реализация пользовательской фабрики контроллеров,
    // наследуясь от фабрики используемой по умолчанию
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            // создание контейнера
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext,
        Type controllerType)
        {
            // получение объекта контроллера из контейнера
            // используя его тип
            return controllerType == null
            ? null
            : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            // конфигурирование контейнера
//            Mock<IRecordService> mock = new Mock<IRecordService>();
//            mock.Setup(m => m.GetTopics).Returns(new List<TopicDTO> {
//new TopicDTO { TopicName = "Football", TopicAdmin = "Vasya" },
//new TopicDTO { TopicName = "Surf board", TopicAdmin = "Masha" },
//new TopicDTO { TopicName = "Running shoes", TopicAdmin = "Kolya" }
//}.AsQueryable());
            //ninjectKernel.Bind<IRecordService>().ToConstant(mock.Object);
            ninjectKernel.Bind<IRecordService>().To<RecordService>();
        }
    }
}