var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
let FetchDataComponent = class FetchDataComponent {
    constructor(http, baseUrl) {
        this.http = http;
        this.baseUrl = baseUrl;
        this.name = "test";
        http.get(baseUrl + 'weatherforecast').subscribe(result => {
            this.forecasts = result;
        }, error => console.error(error));
        this.loadCourses();
    }
    loadCourses() {
        this.http.get(this.baseUrl + 'api/Courses').subscribe(result => {
            this.courses = result;
            console.log(this.courses);
        }, error => console.error(error));
    }
    submit() {
        var course = {};
        course.name = this.name;
        course.category = Category.Writing;
        course.difficulty = Difficulty.Beginner;
        course.durationInMin = 160;
        course.dateAdded = new Date();
        this.http.post(this.baseUrl + 'api/Courses', course).subscribe(result => {
            console.log('Success!');
            this.loadCourses();
        }, error => {
            if (error.status == 400) {
                console.log(error.error.errors);
            }
        });
    }
};
FetchDataComponent = __decorate([
    Component({
        selector: 'app-fetch-data',
        templateUrl: './fetch-data.component.html'
    }),
    __param(1, Inject('BASE_URL')),
    __metadata("design:paramtypes", [HttpClient, String])
], FetchDataComponent);
export { FetchDataComponent };
var Difficulty;
(function (Difficulty) {
    Difficulty[Difficulty["Beginner"] = 0] = "Beginner";
    Difficulty[Difficulty["Intermediate"] = 1] = "Intermediate";
    Difficulty[Difficulty["Advanced"] = 2] = "Advanced";
})(Difficulty || (Difficulty = {}));
var Category;
(function (Category) {
    Category[Category["Writing"] = 0] = "Writing";
    Category[Category["Music"] = 1] = "Music";
    Category[Category["Finance"] = 2] = "Finance";
    Category[Category["Design"] = 3] = "Design";
    Category[Category["Photography"] = 4] = "Photography";
    Category[Category["Culinary"] = 5] = "Culinary";
    Category[Category["Entertainment"] = 6] = "Entertainment";
    Category[Category["Society"] = 7] = "Society";
    Category[Category["Technology"] = 8] = "Technology";
})(Category || (Category = {}));
//# sourceMappingURL=fetch-data.component.js.map