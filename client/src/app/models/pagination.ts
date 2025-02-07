import { Product } from "./product";

export interface Pagination {
    pageSize: number,
    pageNumber: number,
    totalCount: number,
    totalPages: number,

    products: Product[]
}