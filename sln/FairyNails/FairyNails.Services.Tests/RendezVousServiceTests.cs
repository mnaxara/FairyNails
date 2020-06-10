using System;
using Xunit;
using FluentAssertions;
using Moq;
using FairyNails.Service.RendezVousServices;
using System.Collections.Generic;
using FairyNails.Service.Entity;
using System.Linq;
using FairyNails.Service;
using static FairyNails.Service.RendezVousServices.RendezVousService;

namespace FairyNails.Services.Tests
{
    public class RendezVousServiceTests
    {
        private readonly string idUser = "123";
        private readonly List<int> prestationsIdList = new List<int>() { 1 };
        //dateCode : YYYY-MM-dd-HH
        private readonly string dateCode = "2020-02-03-09";
        private readonly string comments = "comments";
        private readonly TPrestation fakePrestation = new TPrestation()
        {
            IdPrestation = 1,
            Description = "desc",
            Duree = TimeSpan.FromHours(1),
            Nom = "Name",
            Prix = 20
        };

        [Fact]
        public void AddRendezVous_Return_True_With_Good_Entries()
        {
            //Arrange          
            //----Mock & Setup Context
            var contextMock = SetupAddRendezVousContextMock(fakePrestation);
            //----Service
            var rendezVousService = new RendezVousService(contextMock);
            //Act
            var result = rendezVousService.AddRendezVous(idUser, prestationsIdList, dateCode, comments);
            //Assert
            Mock.Get(contextMock).Verify(c => c.AddRange(It.IsAny<List<TRendezVousHasPrestation>>()), Times.Once);
            Mock.Get(contextMock).Verify(c => c.SaveChanges(), Times.Once);
            Assert.True(result);
        }

        [Fact]
        public void AddRendezVous_Create_RendezVous_WithGoodProperties()
        {
            //Arrange
            //----Mock & Setup Context
            var contextMock = SetupAddRendezVousContextMock(fakePrestation);
            //----Service
            var rendezVousService = new RendezVousService(contextMock);
            //Act
            var result = rendezVousService.AddRendezVous(idUser, prestationsIdList, dateCode, comments);
            //Assert
            Mock.Get(contextMock).Verify(c => c.AddRange(It.Is<List<TRendezVousHasPrestation>>(l => l.First().IdRdvNavigation.Comments.Equals(comments))));
            Mock.Get(contextMock).Verify(c => c.AddRange(It.Is<List<TRendezVousHasPrestation>>(l => l.First().IdRdvNavigation.PrixTotal.Equals(fakePrestation.Prix))));
            Mock.Get(contextMock).Verify(c => c.AddRange(It.Is<List<TRendezVousHasPrestation>>(l => l.First().IdRdvNavigation.DureeTotal.Equals(fakePrestation.Duree))));
        }

        [Fact]
        public void ConvertTimeCodeInDateTime_Return_Good_Datetime()
        {
            //Arrange
            //----Expected parameter
            DateTime dateCodeTransform = new DateTime(2020, 02, 03, 09, 00, 00);
            //----Mock & Setup Context
            var contextStub = Mock.Of<FairynailsContext>();
            //----Service
            var rendezVousService = new RendezVousService(contextStub);
            //Act
            var result = rendezVousService.ConvertTimeCodeInDateTime(dateCode);
            //Assert
            Assert.Equal(dateCodeTransform, result);
        }

        [Fact]
        public void AddTimeBetweenRdv_Return_CorrectDateCode_With_Rdv()
        {
            //Arrange
            var rdvList = new List<ValidRendezVousDateAndDuration>
            {
                new ValidRendezVousDateAndDuration()
                {
                    DateRdv = new DateTime(2020,02,03,09,00,00),
                    Duration = TimeSpan.FromHours(3)
                }
            };
            //----Expected Parameter
            var dateCodes = new List<string>()
            {
                "2020-2-3-9",
                "2020-2-3-10",
                "2020-2-3-11",
                "2020-2-3-12"
            };
            //----Mock & Setup Context
            var contextStub = Mock.Of<FairynailsContext>();
            //----Service
            var rendezVousService = new RendezVousService(contextStub);
            //Act
            var result = rendezVousService.AddTimeBetweenRdv(rdvList);
            //Assert
            Assert.Equal(dateCodes, result);
        }

        [Fact]
        public void AddTimeBetweenRdv_Return_EmptyList_With_NoRdv()
        {
            //Arrange
            var rdvList = new List<ValidRendezVousDateAndDuration>();
            //----Expected Parameter
            var dateCodes = new List<string>();
            //----Mock & Setup Context
            var contextStub = Mock.Of<FairynailsContext>();
            //----Service
            var rendezVousService = new RendezVousService(contextStub);
            //Act
            var result = rendezVousService.AddTimeBetweenRdv(rdvList);
            //Assert
            Assert.Equal(dateCodes, result);
        }

        private FairynailsContext SetupAddRendezVousContextMock(TPrestation fakePrestation)
        {
            var contextMock = Mock.Of<FairynailsContext>();
            Mock.Get(contextMock)
                .Setup(c => c.SaveChanges())
                .Returns(1);
            Mock.Get(contextMock)
                .Setup(c => c.TPrestation.Find(1))
                .Returns(fakePrestation);
            Mock.Get(contextMock)
                .Setup(c => c.Users.Find())
                .Returns(new ApplicationUser());

            return contextMock;
        }
    }
}
