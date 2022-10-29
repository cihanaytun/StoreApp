import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { delay, finalize, Observable } from "rxjs";
import { BusyService } from "../services/busy.service";

@Injectable()
export class LoadingInterceptor implements HttpInterceptor{

    constructor(private busyService:BusyService){}

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        
        if (request.method === 'POST' && request.url.includes('orders')) {
            return next.handle(request);
        }
        if (request.method ==="DELETE") {
            return next.handle(request);
        }
        
        if (!request.url.includes('emailexists')) {
            this.busyService.busy();
        }
        
        //this.busyService.busy(); burayı açınca program başlarken spinner hep çalışşıyor
        return next.handle(request).pipe(
        delay(1000),
        finalize(() => {
            this.busyService.idle();
        })
       );
    }


}