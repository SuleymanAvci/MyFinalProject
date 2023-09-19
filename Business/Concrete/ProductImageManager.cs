using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        IProductImageDal _productImageDal;
        IFileHelper _fileHelper;

        public ProductImageManager(IFileHelper fileHelpers, IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
            _fileHelper = fileHelpers;

        }

        public IResult Add(IFormFile file, ProductImage productImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExceded(productImage.ProductId));
            if (result != null)
            {
                return result;
            }

            productImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            productImage.Date = DateTime.Now;
            _productImageDal.Add(productImage);
            return new SuccessResult("Resim Başarı ile yüklendi");
        }

        public IResult Delete(ProductImage productImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + productImage.ImagePath);
            _productImageDal.Delete(productImage);
            return new SuccessResult();
        }

        public IResult Update(IFormFile file, ProductImage productImage)
        {
            productImage.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + productImage.ImagePath, PathConstants.ImagesPath);
            _productImageDal.Update(productImage);
            return new SuccessResult();
        }

        public IDataResult<ProductImage> GetById(int imageId)
        {
            return new SuccessDataResult<ProductImage>(_productImageDal.Get(c => c.Id == imageId));
        }

        public IDataResult<List<ProductImage>> GetAll()
        {
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll());
        }


        public IDataResult<List<ProductImage>> GetByProductId(int productId)
        {
            var result = BusinessRules.Run(CheckIfAnyImageExists(productId));
            {
                if (result != null)
                {
                    return new ErrorDataResult<List<ProductImage>>(GetDefaultImage(productId).Data);
                }

                return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll(c => c.ProductId == productId));
            }
        }


        private IResult CheckIfImageLimitExceded(int productId)
        {
            var result = _productImageDal.GetAll(p => p.ProductId == productId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IDataResult<List<ProductImage>> GetDefaultImage(int productId)
        {
            List<ProductImage> defaultImage = new List<ProductImage>();
            defaultImage.Add(new ProductImage { ProductId = productId, Date = DateTime.Now, ImagePath = "default.png" });
            return new SuccessDataResult<List<ProductImage>>(defaultImage);
        }

        private IResult CheckIfAnyImageExists(int productId)
        {
            var result = _productImageDal.GetAll(c => c.ProductId == productId);
            if (result.Any())
            {
                return new SuccessResult();
            }

            return new ErrorResult();
        }

    }
}
