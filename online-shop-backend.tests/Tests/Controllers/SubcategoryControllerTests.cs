using Newtonsoft.Json;
using online_shop_backend.Controllers;
using online_shop_backend.Models.DTO;
using online_shop_backend.Repositories.Interfaces;
using online_shop_backend.tests.Mocks;
using Xunit;

namespace online_shop_backend.tests.Tests.Controllers
{
    public class SubcategoryControllerTests
    {
        private readonly IProducerRepository producerRepository;
        private readonly ISubcategoriesRepository subcategoriesRepository;
        private readonly SubcategoryController subcategoryController;

        public SubcategoryControllerTests()
        {
            subcategoriesRepository = new SampleSubcategoriesRepository();
            producerRepository = new SampleProducerRepository();
            subcategoryController = new SubcategoryController(subcategoriesRepository, producerRepository);
        }

        [Fact]
        public void ReturnsAListOfAllSubcategories()
        {
            var result = subcategoryController.Index();

            Assert.Equal(JsonConvert.SerializeObject(result),
                JsonConvert.SerializeObject(subcategoriesRepository.GetAllSubcategories()));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        public void ReturnsSubcategoryAndItsProducts(int id)
        {
            var result = subcategoryController.Subcategory(id, null, null);

            var expected = new SubcategoryPageDto
            {
                Subcategory = subcategoriesRepository.GetSubcategory(id),
                Products = subcategoriesRepository.GetProductsForSubcategory(id)
            };

            Assert.Equal(JsonConvert.SerializeObject(expected),
                JsonConvert.SerializeObject(result));
        }
    }
}