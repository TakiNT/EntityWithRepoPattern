import Ember from "ember";

export default Ember.Route.extend({
	controllerName: "post",
	modelName: "post",
	setupController: function(controller, model){
		console.log(this.connections);
		controller.getNewestPost();
	}
});