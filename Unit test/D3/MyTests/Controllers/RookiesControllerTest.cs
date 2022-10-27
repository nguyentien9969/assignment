using Moq;
using MVC.Controllers;
using MVC.Models;
using MVC.Service;
using NUnit.Framework;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace MyTests.Controllers
{
    public class RookiesControllerTest
    {
        private Mock<ILogger<RookieController>> _loggerMock;
        private Mock<IMemberService> _memberServiceMock;
        private RookieController _sut;
        private static List<MemberModel> _data = new()
        {
            new MemberModel()
            {
                FirstName = "Tien",
                LastName = "Nguyen",
                BirthPlace = "HaNoi",
            },
             new MemberModel()
            {
                FirstName = "Trang",
                LastName = "Thu",
                BirthPlace = "HaNoi",
            }
        };

        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger<RookieController>>();
            _memberServiceMock = new Mock<IMemberService>();
            _sut = new RookieController(_loggerMock.Object, _memberServiceMock.Object);
            _memberServiceMock.Setup(x => x.GetAll()).Returns(_data);
        }

        [Test]
        public void GetAllMember_ReturnViewResult_WithAListOfMember()
        {
            var result = _sut.Index();

            Assert.IsInstanceOf<ViewResult>(result);

            var view = (ViewResult)result;
            Assert.IsInstanceOf<List<MemberModel>>(view.ViewData.Model);
            Assert.IsAssignableFrom<List<MemberModel>>(view.ViewData.Model);

            var list = (List<MemberModel>)view.ViewData.Model;
            Assert.AreEqual(2, list.Count());
        }

        [Test]
        public void UpdatePost_ReturnBadRequest_WhenModelStateIsInValid()
        {
            _sut.ModelState.AddModelError("FirstName", "FieldRequired");
            var index = 1;
            var updateMember = new MemberUpdateModel();

            var result = _sut.Update(index, updateMember);

            Assert.IsInstanceOf<BadRequestObjectResult>(result);
            var badRequestResult = (BadRequestObjectResult)result;
            var serialize = (SerializableError)badRequestResult.Value;
            var a = badRequestResult.Value.ToString();
            Assert.AreEqual("FirstName", serialize.Keys.ToList()[0] as string);
        }

        [Test]
        public void UpdatePost_ReturnARedirectToAction_WhenModelStateIsValid()
        {
            var member = new MemberModel();
            var index = 3;
            var updateMember = new MemberUpdateModel()
            {
                FirstName = "T",
            };

            var result = _sut.Update(index, updateMember);

            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = (RedirectToActionResult)result;
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [Test]
        public void Detail_ReturnRedirectToActionIndex_WhenIdIsNull()
        {
            int index = 1;
            _memberServiceMock.Setup(x => x.GetOne(index)).Returns(_data[0]);
           
            var result = _sut.Detail(index);
          
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void Detail_ReturnContent_WhenMemberIsNotFound()
        {

            var testId = 3;
            _memberServiceMock.Setup(x => x.GetOne(testId)).Returns((MemberModel)null);

            var result = _sut.Detail(testId);

            Assert.IsInstanceOf<ContentResult>(result);
            var contentResult = (ContentResult)result;
            Assert.AreEqual("NotFound", contentResult.Content);
        }

        [Test]
        public void Edit_ReturnBadRequest_WhenMemberIsNotFound()
        {

            var testId = 3;
            _memberServiceMock.Setup(x => x.GetOne(testId)).Returns((MemberModel)null);

            var result = _sut.Edit(testId);

            Assert.IsInstanceOf<BadRequestResult>(result);
            var badRequest = (BadRequestResult)result;
        }


        [Test]
        public void Edit_ReturnView_WhenMemberIsFound()
        {
            _memberServiceMock.Setup(x => x.GetOne(1)).Returns(_data[0]);

            var result = _sut.Edit(1);

            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = (ViewResult)result;
            Assert.IsInstanceOf<MemberUpdateModel>(viewResult.ViewData.Model);
        }

        [Test]
        public void Delete_ReturnNotFound_whenMemberIsDeleted()
        {
            var result = _sut.Delete(1);

            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Delete_ReturnRedirectToAction_whenMemberIsDeleted()
        {
            var deletedMember = _memberServiceMock.Setup(x => x.Delete(0)).Returns(_data[0]);

            var result = _sut.Delete(0);

            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToAction = (RedirectToActionResult)result;
            Assert.AreEqual("Index", redirectToAction.ActionName);
        }

        [Test]
        public void DeleteAndRedirectToResultView_ReturnRedirectToAction_WhenSuccess()
        {
            var deletedMember = _memberServiceMock.Setup(x => x.Delete(0)).Returns(_data[0]);

            var result = _sut.Delete(0);

            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToAction = (RedirectToActionResult)result;
            Assert.AreEqual("Index", redirectToAction.ActionName);
        }

        [Test]
        public void Create_ReturnRedirectToActionResult_WhenModelStateIsInValid()
        {
            _sut.ModelState.AddModelError("FirstName", "FirstNameRequired");

            var result = _sut.Create(model: null);

            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void Create_ReturnView_WhenModelStateIsValid()
        {
            var newCreatedMember = new MemberCreateModel()
            {
                FirstName = "T"
            };
            var result = _sut.Create(newCreatedMember);

            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var actionResult = (RedirectToActionResult)result;
            Assert.AreEqual("Index", actionResult.ActionName);
        }
    }
}