﻿using Application.Interfaces.Repositories;
using AutoMapper;
using ECommerce.Application.Interfaces.Services;
using ECommerce.Application.Models;
using ECommerce.Application.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<SaveProductViewModel> AddAsync(SaveProductViewModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);
            product = await _productRepository.AddAsync(product);

            SaveProductViewModel productVm = _mapper.Map<SaveProductViewModel>(product);
            return productVm;
        }

        public async Task UpdateAsync(SaveProductViewModel productViewModel, int id)
        {
           var product = _mapper.Map<Product>(productViewModel);
           await _productRepository.UpdateAsync(product, id);
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            await _productRepository.DeleteAsync(product);
        }

        public async Task<List<ProductViewModel>> GetAllAsync()
        {
            var productList = await _productRepository.GetAllAsync();
            return _mapper.Map<List<ProductViewModel>>(productList);
        }

        public async Task<SaveProductViewModel> GetByIdAsync(int id) 
        {
            var product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<SaveProductViewModel>(product);
        }



    }
}
