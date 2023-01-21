"use strict";(self.webpackChunkclient=self.webpackChunkclient||[]).push([[607],{8607:(U,a,s)=>{s.r(a),s.d(a,{OrdersModule:()=>b});var d=s(6895),l=s(4466),i=s(6949),e=s(1571),u=s(2340),p=s(529);let c=(()=>{class t{constructor(r){this.http=r,this.baseUrl=u.N.apiUrl}getOrdersForUser(){return this.http.get(this.baseUrl+"orders")}getOrderDetailed(r){return this.http.get(this.baseUrl+"orders/"+r)}}return t.\u0275fac=function(r){return new(r||t)(e.LFG(p.eN))},t.\u0275prov=e.Yz7({token:t,factory:t.\u0275fac,providedIn:"root"}),t})();function m(t,o){if(1&t&&(e.TgZ(0,"tr",6)(1,"th"),e._uU(2),e.qZA(),e.TgZ(3,"td"),e._uU(4),e.ALo(5,"date"),e.qZA(),e.TgZ(6,"td"),e._uU(7),e.ALo(8,"currency"),e.qZA(),e.TgZ(9,"td"),e._uU(10),e.qZA()()),2&t){const r=o.$implicit;e.MGl("routerLink","/orders/",r.id,""),e.xp6(2),e.hij("#",r.id,""),e.xp6(2),e.Oqu(e.xi3(5,5,r.orderDate,"medium")),e.xp6(3),e.Oqu(e.lcZ(8,8,r.total)),e.xp6(3),e.Oqu(r.status)}}let h=(()=>{class t{constructor(r){this.ordersService=r}ngOnInit(){this.getOrders()}getOrders(){this.ordersService.getOrdersForUser().subscribe(r=>{this.orders=r},r=>{console.log(r)})}}return t.\u0275fac=function(r){return new(r||t)(e.Y36(c))},t.\u0275cmp=e.Xpm({type:t,selectors:[["app-orders"]],decls:16,vars:1,consts:[[1,"container","mt-5"],[1,"row"],[1,"col-12"],[1,"table","table-hover",2,"cursor","pointer"],[1,"thead-light"],[3,"routerLink",4,"ngFor","ngForOf"],[3,"routerLink"]],template:function(r,n){1&r&&(e.TgZ(0,"div",0)(1,"div",1)(2,"div",2)(3,"table",3)(4,"thead",4)(5,"tr")(6,"th"),e._uU(7,"Order"),e.qZA(),e.TgZ(8,"th"),e._uU(9,"Date"),e.qZA(),e.TgZ(10,"th"),e._uU(11,"Total"),e.qZA(),e.TgZ(12,"th"),e._uU(13,"Status"),e.qZA()()(),e.TgZ(14,"tbody"),e.YNc(15,m,11,10,"tr",5),e.qZA()()()()()),2&r&&(e.xp6(15),e.Q6J("ngForOf",n.orders))},dependencies:[d.sg,i.rH,d.H9,d.uU]}),t})();var O=s(8909),g=s(9281);function v(t,o){if(1&t&&(e.TgZ(0,"div",2)(1,"div",3),e._UZ(2,"app-basket-summary",4),e.qZA(),e.TgZ(3,"div",5),e._UZ(4,"app-order-totals",6),e.qZA()()),2&t){const r=e.oxw();e.xp6(2),e.Q6J("items",r.order.orderItems)("isBasket",!1)("isOrder",!0),e.xp6(2),e.Q6J("shippingPrice",r.order.shippingPrice)("subtotal",r.order.subtotal)("order",r.order.total)}}const f=[{path:"",component:h},{path:":id",component:(()=>{class t{constructor(r,n,T){this.route=r,this.breadcrumbService=n,this.orderService=T,this.breadcrumbService.set("@OrderDetailed"," ")}ngOnInit(){this.orderService.getOrderDetailed(+this.route.snapshot.paramMap.get("id")).subscribe(r=>{this.order=r,this.breadcrumbService.set("@OrderDetailed",`Order# ${r.id} - ${r.status}`)},r=>{console.log(r)})}}return t.\u0275fac=function(r){return new(r||t)(e.Y36(i.gz),e.Y36(O.pm),e.Y36(c))},t.\u0275cmp=e.Xpm({type:t,selectors:[["app-order-detailed"]],decls:2,vars:1,consts:[[1,"container","mt-5"],["class","row",4,"ngIf"],[1,"row"],[1,"col-8"],[3,"items","isBasket","isOrder"],[1,"col-4"],[3,"shippingPrice","subtotal","order"]],template:function(r,n){1&r&&(e.TgZ(0,"div",0),e.YNc(1,v,5,6,"div",1),e.qZA()),2&r&&(e.xp6(1),e.Q6J("ngIf",n.order))},dependencies:[d.O5,g.S]}),t})(),data:{breadcrumb:{alias:"OrderDetailed"}}}];let Z=(()=>{class t{}return t.\u0275fac=function(r){return new(r||t)},t.\u0275mod=e.oAB({type:t}),t.\u0275inj=e.cJS({imports:[d.ez,i.Bz.forChild(f),i.Bz]}),t})(),b=(()=>{class t{}return t.\u0275fac=function(r){return new(r||t)},t.\u0275mod=e.oAB({type:t}),t.\u0275inj=e.cJS({imports:[d.ez,l.m,Z]}),t})()}}]);