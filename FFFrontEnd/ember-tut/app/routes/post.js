import Ember from "ember";

export default Ember.Route.extend({
	controllerName: "post",
	adapter: "post",
	setupController: function(controller, model){
		console.log(this.store.find("post"));
		controller.getNewestPost();
	}
});