import React, { useEffect, useState } from 'react'
import ApiHelper from '../helpers/api';
import { Table} from 'react-bootstrap'

const ProductList=(props)=>{

    const [product, setProduct] = useState([]);
    const [productsList, setProductsList] = useState([]);
    useEffect(() => {
        ApiHelper.Products.getAll().then((res) => {
            setProduct(res)
        })
    },[])
    function display() {
        const getCategoryId = window.location.href.substring(31);
        //console.log(getCategoryId);
        // let newProductsList=[];
        // product.map((pr)=>
        //     {
        //         console.log(pr.categoryId==getCategoryId);
        //         //  console.log("pr.catID" + pr.categoryId);
        //         //  console.log("getcatID" + getCategoryId);

        //         if(pr.categoryId === getCategoryId)
        //         {
        //             newProductsList.Add(pr);
        //         }
                   
                
        //     });
        // let toRender;
        // if(newProductsList){
            
        //     newProductsList.map((pr)=>
        //     {
        //       toRender=(
        //         <Table striped bordered hover>
        //             <thead>
        //                 <tr>
        //                     <th>ID </th>
        //                     <th>Name</th>
        //                     <th>Description</th>
        //                     <th>Category</th>
        //                     <th>Price</th>
        //                     <th>Base Price</th>
        //                 </tr>
        //             </thead>
        //             <tbody>
                        
        //                 <tr key={pr.productId}>
        //                     <td>{pr.productId}</td>
        //                     <td>{pr.name}</td>
        //                     <td>{pr.description}</td>
        //                     <td>{pr.categoryId}</td>
        //                     <td>{pr.price}</td>
        //                     <td>{pr.basePrice}</td>
        //                 </tr>
                        
        //             </tbody>
        //         </Table>

        //       )

                    

        //     });
        // }
        // else{
        //     toRender=(
        //     <div> {getCategoryId}</div>
        //     )
        // }

                  
     
        //return toRender;

        return (
            <div>{getCategoryId}</div>
        );
      }

    return (
        <div>
            <h2>Products</h2>
            {display()}
            </div>
    )
}
export default ProductList;