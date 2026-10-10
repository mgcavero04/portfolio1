import { useFetchProductsQuery } from "./catalogApi";
import ProductList from "./ProductList";



export default function Catalog() {
  const {data, isLoading} = useFetchProductsQuery();//hook from RTK query to fetch products from the API
  if (isLoading || !data) return <h3>Loading...</h3>
  return (
    <>
   <ProductList products={data} />
    
    </>
  )
}