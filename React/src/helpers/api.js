import { API_ROUTE } from "../config/api";
import Category from "../Models/category";
import Product from '../Models/product'
const ApiClient = {
  get: (url, headers = {}) => {
    return ApiClient.makeRequest(`${API_ROUTE}/${url}`, "GET", {}, headers);
  },
  post:(url,headers)=>{
 return ApiClient.makeRequest(`${API_ROUTE}/${url}`,"POST",headers)
  },
  delete:(url,id,headers = {})=>{
    return ApiClient.makeRequest(`${API_ROUTE}/${url}`,"DELETE",id,headers)
  },
  put:(url,id,headers)=>{
return ApiClient.makeRequest(`${API_ROUTE}/${url}`,"PUT",id,headers)
  },
  makeRequest: async (url, type, params = {}, headers = {}) => {
    try {
      type = type.toUpperCase();
     
      let request = {
    
        method: type,
          headers:headers
      }
      if (type === "POST" || type === "PUT") {

        request.headers={"content-Type": "application/json;charset=UTF-8"}
        request.body = JSON.stringify(params);
        
      }
      
      const result = await fetch(url, request);
      return await result.json();
    } catch (error) {
      throw error.message;
    }
  },
};

const ProductCategories = {
  all: async () => {
    const { categories } = await ApiClient.get("category");

    return categories.map((c) => new Category(c.categoryId, c.name, c.description));
  },
  post:async (params) =>{
      return  await ApiClient.post("category",params);
  },
  delete:async(id)=>{
    return await ApiClient.delete(`category/${id}`);
  },
  update:async(id,params)=>{
    return await ApiClient.put(`category/${id}`,params)
  }
};

const Products={
  getImage:async(id)=>{
    return await ApiClient.get(`Produt/${id}`);
   
  },
  getAll:async()=>{
    const { products } = await ApiClient.get("product");

    return products.map((p) => new Product(p.productId, p.name, p.price, p.basePrice, p.description, p.categoryId, p.image)); 
  },
  post:async (params)=>{
    return await ApiClient.post("Product",params)
  },
  postImage:async (params,id)=>{
    return await  ApiClient.post(`product/image/${id}`,params);
  },
  delete:async (id)=>{
    return await ApiClient.delete(`product/${id}`);
  }
}
const ApiHelper = {
  ProductCategories,
  Products
};
export default ApiHelper;
