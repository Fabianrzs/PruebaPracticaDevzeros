import { Component, OnInit } from '@angular/core';
import { Book } from 'src/app/Elements/models/book';
import { AuthenticationService } from 'src/app/Elements/services/authentication.service';
import { BookService } from 'src/app/Elements/services/Book.service';
import { SignalRService } from 'src/app/Elements/services/SignalR.service';

@Component({
  selector: 'app-consult-books',
  templateUrl: './consult-books.component.html',
  styleUrls: ['./consult-books.component.css']
})
export class ConsultBooksComponent implements OnInit {

  books: Book[];
  book: Book;
  bookAdd: Book;

  BOOKS: Book[];
  page = 1;
  pageSize = 3;
  collectionSize = 0;


  constructor(
    private service: BookService,
    private signalService: SignalRService,
    private authenticationService: AuthenticationService
  ) { }

  ngOnInit() {
    this.book= new Book();
    this.bookAdd = new Book();
    this.get();

    this.signalService.signalReceived
    .subscribe((signal:Book) => {
      this.get();
    });
  }
  get() {
    this.service.get().subscribe(result => {
      this.BOOKS = result;
      this.collectionSize = this.BOOKS.length;

      this.books = this.BOOKS.map((servicios, i) => ({
        id: i + 1,
        ...servicios,
      })).slice(
        (this.page - 1) * this.pageSize,
        (this.page - 1) * this.pageSize + this.pageSize
      );
    });
  }
  update() {
    this.service.put(this.book).subscribe(result => {
      this.get();
    });
    
  }
  delete(codBook: number) {
    this.service.delete(codBook).subscribe(result => {this.get();});
   
  }
  getId(codBook: number){
    this.service.getId(codBook).subscribe(result => {
      this.book = result;
    });
  }

  add(){
    this.service.post(this.bookAdd).subscribe(result => {
      result = this.bookAdd;
    });
  }

  exit(){
    this.authenticationService.logout();
  }

}
