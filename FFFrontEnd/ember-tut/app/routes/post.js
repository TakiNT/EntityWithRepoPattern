import Ember from "ember";

export default Ember.Route.extend({
	controllerName: "Post",
	adapter: "Post",
	setupController: function(controller){
		console.log(this.store.all("post"));
		console.log("abc");
		controller.getNewestPost();
	}
});