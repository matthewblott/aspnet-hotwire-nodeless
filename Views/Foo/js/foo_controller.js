import { Controller } from "stimulus"

export default class FooController extends Controller {

  connect() {
    this.sayHi('foo');
  }

  sayHi(controllerName) {
    console.log(`Hello from the '${controllerName}' controller.`, this.element);
  }
}
