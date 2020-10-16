import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { TestErrorComponent } from './core/test-error/test-error.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { StudentCompletedComponent } from './core/student-completed/student-completed.component';
import { StudentMyStuffComponent } from './core/student-my-stuff/student-my-stuff.component';
import { StudentMyTodoComponent } from './core/student-my-todo/student-my-todo.component';
import { TeacherManageStudentComponent } from './core/teacher-manage-student/teacher-manage-student.component';
import { TeacherHomeComponent } from './core/teacher-home/teacher-home.component';
import { TeacherClassHomeComponent } from './core/teacher-class-home/teacher-class-home.component';
import { TeacherManageAssignmentComponent } from './core/teacher-manage-assignment/teacher-manage-assignment.component';
import { TeacherManageClassComponent } from './core/teacher-manage-class/teacher-manage-class.component';
import { TeacherManageContentComponent } from './core/teacher-manage-content/teacher-manage-content.component';
import { TeacherToolboxComponent } from './core/teacher-toolbox/teacher-toolbox.component';


const routes: Routes = [
  {path: '', component: HomeComponent, data: {breadcrumb: 'Home'}},
  {path: 'student-completed', component: StudentCompletedComponent, data: {breadcrumb: 'Student Completed'}},
  {path: 'student-my-todo', component: StudentMyTodoComponent, data: {breadcrumb: 'Student My To Do'}},
  {path: 'student-my-stuff', component: StudentMyStuffComponent, data: {breadcrumb: 'Student My Stuff'}},
  {path: 'test-error', component: TestErrorComponent, data: {breadcrumb: 'Student Home'}},
  {path: 'teacher-manage-student', component: TeacherManageStudentComponent, data: {breadcrumb: 'Teacher Manage Student'}},
  {path: 'teacher-manage-assignment', component: TeacherManageAssignmentComponent, data: {breadcrumb: 'Teacher Manage Assignment'}},
  {path: 'teacher-manage-class', component: TeacherManageClassComponent, data: {breadcrumb: 'Teacher Manage Class'}},
  {path: 'teacher-manage-content', component: TeacherManageContentComponent, data: {breadcrumb: 'Teacher Manage Content'}},
  {path: 'teacher-toolbox', component: TeacherToolboxComponent, data: {breadcrumb: 'Teacher Toolbox'}},
  {path: 'teacher-home', component: TeacherHomeComponent, data: {breadcrumb: 'Teacher Home'}},
  {path: 'teacher-class-home', component: TeacherClassHomeComponent, data: {breadcrumb: 'Teacher Class Home'}},
  {path: 'server-error', component: ServerErrorComponent, data: {breadcrumb: 'Server Error'}},
  {path: 'not-found', component: NotFoundComponent, data: {breadcrumb: 'Not Found'}},
  // lazy loading
  {path: 'shop', loadChildren: () => import('./shop/shop.module').then(mod => mod.ShopModule), data: {breadcrumb: 'Education Library'}},
  {path: 'basket', loadChildren: () => import('./basket/basket.module').then(mod => mod.BasketModule), data: {breadcrumb: 'Basket'}},
  {path: 'checkout', loadChildren: () => import('./checkout/checkout.module')
  .then(mod => mod.CheckoutModule), data: {breadcrumb: 'Checkout'}},
  {path: 'account', loadChildren: () => import('./account/account.module')
  .then(mod => mod.AccountModule), data: {breadcrumb: {skip: true}}},
  // if someone types in a bad url this line below should take them back to the home page
  {path: '**', redirectTo: 'not-found', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
