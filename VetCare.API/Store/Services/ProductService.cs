using VetCare.API.Store.Domain.Models;
using VetCare.API.Store.Domain.Repositories;
using VetCare.API.Store.Domain.Services;
using VetCare.API.Store.Domain.Services.Communication;

namespace VetCare.API.Store.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWorkS _unitOfWorkS;

    public ProductService(IProductRepository productRepository, IUnitOfWorkS unitOfWorkS)
    {
        _productRepository = productRepository;
        _unitOfWorkS = unitOfWorkS;
    }
    
    public async Task<IEnumerable<Product>> ListAsync()
    {
        return await _productRepository.ListAsync();
    }

    public async Task<ProductResponse> SaveAsync(Product product)
    {
        var existingProductWithId = await _productRepository.FindByIdAsync(product.Id);
        if (existingProductWithId !=null)
            return new ProductResponse("Product already exists");

        try
        {
            await _productRepository.AddAsync(product);
            await _unitOfWorkS.CompleteAsync();
            return new ProductResponse(product);
        }
        catch (Exception e)
        {
            return new ProductResponse($"An error occurred while saving the product: {e.Message}");
        }
    }

    public async Task<ProductResponse> UpdateAsync(int productId, Product product)
    {
        // Validate Tutorial
        var existingProduct = await _productRepository.FindByIdAsync(productId);
        if (existingProduct == null)
            return new ProductResponse("Product not found.");
        // Validate Title
        // var existingTutorialWithTitle = await _tutorialRepository.FindByTitleAsync(tutorial.Title);
        // if (existingTutorialWithTitle != null && existingTutorialWithTitle.Id != existingTutorial.Id)
        //      return new TutorialResponse("Tutorial title already exists.");
        
        //VERIFICAR VALIDACION -- AGREGAR EN LA INTERFAZ DEL MODELO FindByNameAsync para validar con nombre
        
        // Modify Fields
        existingProduct.Name = product.Name;
        existingProduct.Description = product.Description;
        existingProduct.Image = product.Image;
        existingProduct.Stock = product.Stock;
        existingProduct.Price = product.Price;
        
        try
        {
            _productRepository.Update(existingProduct);
            await _unitOfWorkS.CompleteAsync();

            return new ProductResponse(existingProduct);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new ProductResponse($"An error occurred while updating the product: {e.Message}");
        }
    }

    public async Task<ProductResponse> DeleteAsync(int productId)
    {
        var existingProduct = await _productRepository.FindByIdAsync(productId);
        
        // Validate Tutorial

        if (existingProduct == null)
            return new ProductResponse("Product not found.");
        
        try
        {
            _productRepository.Remove(existingProduct);
            await _unitOfWorkS.CompleteAsync();

            return new ProductResponse(existingProduct);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new ProductResponse($"An error occurred while deleting the product: {e.Message}");
        }
    }
}