export interface Course {
    id: number;
    name: string;
    category: Category;
    difficulty: Difficulty;
    durationInMin: number;
    dateAdded: Date;
    startDate: Date;
    endDate: Date;
}

export enum Category {
    Writing = 0,
    Music = 1,
    Finance = 2,
    Design = 3,
    Photography = 4,
    Culinary = 5,
    Entertainment = 6,
    Society = 7,
    Technology = 8
}
export enum Difficulty {
    Beginner = 0,
    Intermediate = 1,
    Advanced = 2
}

export interface Review {
    id: number;
    content: string,

}

export interface CourseWithDetails {
    id: number;
    name: string;
    category: Category;
    difficulty: Difficulty;
    durationInMin: number;
    dateadded: Date;
    startdate: Date;
    endDate: Date;
    review: Review[];
}
