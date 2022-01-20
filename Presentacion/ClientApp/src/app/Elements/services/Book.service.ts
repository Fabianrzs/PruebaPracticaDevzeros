import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Book } from '../models/book';
import { HandleHttpErrorService } from './handle-http-error.service';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class BookService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }

  get(): Observable<Book[]> {
    return this.http.get<Book[]>(this.baseUrl + 'api/Book')
      .pipe(
        tap(_ => this.handleErrorService.log('Date Consult')),
        catchError(this.handleErrorService.handleError<Book[]>('Consult Book', null))
      );
  }

  post(paciente: Book): Observable<Book> {
    return this.http.post<Book>(this.baseUrl + 'api/Book', paciente)
      .pipe(
        tap(() => this.handleErrorService.log('Date Save')),
        catchError(this.handleErrorService.handleError<Book>('Register Book', null))
      );
  }

  getId(codBook: number): Observable<Book> {
    const url = `${this.baseUrl + 'api/Book'}/${codBook}`;
    return this.http.get<Book>(url, httpOptions)
      .pipe(
        tap(_ => this.handleErrorService.log('Date Find')),
        catchError(this.handleErrorService.handleError<Book>('Find Book', null))
      );
  }

  put(book: Book): Observable<any> {
    const url = `${this.baseUrl}api/Book/${book.codBook}`;
    return this.http.put(url, book, httpOptions)
    .pipe(
      tap(_ => this.handleErrorService.log('Date Update')),
      catchError(this.handleErrorService.handleError<any>('Update Book'))
    );
  }

  delete(codBook: number): Observable<Book> {
    const url = `${this.baseUrl + 'api/Book'}/${codBook}`;
    return this.http.delete<Book>(url, httpOptions)
      .pipe(
        tap(_ => this.handleErrorService.log('Date Delete')),
        catchError(this.handleErrorService.handleError<Book>('Delete Book', null))
      );
  }

}
