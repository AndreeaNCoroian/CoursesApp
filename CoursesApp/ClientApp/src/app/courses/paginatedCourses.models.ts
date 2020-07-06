import { Course } from "./courses.models";

export interface PaginatedCourses {
    currentPage: number;
    totalItems: number;
    itemsPerPage: number;
    totalPages: number;
    items: Course[];
}
