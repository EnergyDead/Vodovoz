node('Vod6'){
	stage('Test'){
		def projectInstance = jenkins.model.Jenkins.instance.getItem(env.JOB_NAME.minus("/${env.JOB_BASE_NAME}"))
		projectInstance.getItems().each { job ->
        	echo job.getProperty(org.jenkinsci.plugins.workflow.multibranch.BranchJobProperty.class).getBranch().getName()
    	}
	}
	// stage('Checkout'){
	// 	def REFERENCE_ABSOLUTE_PATH = "${JENKINS_HOME_WIN}/workspace/Vodovoz_Vodovoz_master"

	// 	echo "checkout Gtk.DataBindings"	
	// 	checkout changelog: false, poll: false, scm:([
	// 		$class: 'GitSCM',
	// 		branches: [[name: '*/vodovoz']],
	// 		doGenerateSubmoduleConfigurations: false,
	// 		extensions: 
	// 		[[$class: 'RelativeTargetDirectory', relativeTargetDir: 'Gtk.DataBindings']]
	// 		+ [[$class: 'CloneOption', reference: "${REFERENCE_ABSOLUTE_PATH}/Gtk.DataBindings"]],
	// 		userRemoteConfigs: [[url: 'https://github.com/QualitySolution/Gtk.DataBindings.git']]
	// 	])

	// 	echo "checkout GMap.NET"	
	// 	checkout changelog: false, poll: false, scm:([
	// 		$class: 'GitSCM',
	// 		branches: [[name: '*/master']],
	// 		doGenerateSubmoduleConfigurations: false,
	// 		extensions:
	// 		[[$class: 'RelativeTargetDirectory', relativeTargetDir: 'GMap.NET']]
	// 		+ [[$class: 'CloneOption', reference: "${REFERENCE_ABSOLUTE_PATH}/GMap.NET"]],
	// 		userRemoteConfigs: [[url: 'https://github.com/QualitySolution/GMap.NET.git']]
	// 	])

	// 	echo "checkout My-FyiReporting"	
	// 	checkout changelog: false, poll: false, scm:([
	// 		$class: 'GitSCM',
	// 		branches: [[name: '*/QSBuild']],
	// 		doGenerateSubmoduleConfigurations: false,
	// 		extensions:
	// 		[[$class: 'RelativeTargetDirectory', relativeTargetDir: 'My-FyiReporting']]
	// 		+ [[$class: 'CloneOption', reference: "${REFERENCE_ABSOLUTE_PATH}/My-FyiReporting"]],
	// 		userRemoteConfigs: [[url: 'https://github.com/QualitySolution/My-FyiReporting.git']]
	// 	])

	// 	echo "checkout QSProjects"	
	// 	checkout changelog: false, poll: false, scm:([
	// 		$class: 'GitSCM',
	// 		branches: [[name: '*/master']],
	// 		doGenerateSubmoduleConfigurations: false,
	// 		extensions:
	// 		[[$class: 'RelativeTargetDirectory', relativeTargetDir: 'QSProjects']]
	// 		+ [[$class: 'CloneOption', reference: "${REFERENCE_ABSOLUTE_PATH}/QSProjects"]],
	// 		userRemoteConfigs: [[url: 'https://github.com/QualitySolution/QSProjects.git']]
	// 	])

	// 	echo "checkout Vodovoz"	
	// 	checkout changelog: false, poll: false, scm:([
	// 		$class: 'GitSCM',
	// 		branches: scm.branches,
	// 		doGenerateSubmoduleConfigurations: scm.doGenerateSubmoduleConfigurations,
	// 		extensions: scm.extensions 
	// 		+ [[$class: 'RelativeTargetDirectory', relativeTargetDir: 'Vodovoz']]
	// 		+ [[$class: 'CloneOption', reference: "${REFERENCE_ABSOLUTE_PATH}/Vodovoz"]],
	// 		userRemoteConfigs: scm.userRemoteConfigs
	// 	])
	// }
	// stage('Restore'){
	// 	echo 'Prepare Vodovoz'	
	// 	bat '"C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Community\\MSBuild\\Current\\Bin\\MSBuild.exe" Vodovoz\\Vodovoz.sln -t:Restore -p:Configuration=DebugWin -p:Platform=x86'
	// }
	// stage('Build'){
	// 	echo 'Build solution'
	// 	bat '"C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Community\\MSBuild\\Current\\Bin\\MSBuild.exe" Vodovoz\\Vodovoz.sln -t:Build -p:Configuration=DebugWin -p:Platform=x86'

	// 	fileOperations([fileDeleteOperation(excludes: '', includes: 'Vodovoz.zip')])
	// 	zip zipFile: 'Vodovoz.zip', archive: false, dir: 'Vodovoz/Vodovoz/bin/DebugWin'
	// 	archiveArtifacts artifacts: 'Vodovoz.zip', onlyIfSuccessful: true
	// }
}
// node('Vod3') {
// 	stage('Deploy'){
// 		echo "Checking the deployment for a branch " + env.BRANCH_NAME
// 		script{
// 			def OUTPUT_PATH = "F:\\WORK\\_BUILDS\\" + env.BRANCH_NAME
// 			if(
// 				env.BRANCH_NAME == 'master'
// 				|| env.BRANCH_NAME == 'develop'
// 				|| env.BRANCH_NAME == 'Beta'
// 				|| env.BRANCH_NAME ==~ /^[Rr]elease(.*?)/
// 				|| env.BRANCH_NAME ==~ /^[Ff]eature(.*?)/
// 				|| env.BRANCH_NAME ==~ /^[Hh]otfix(.*?)/)
// 			{
// 				echo "Deploy branch " + env.BRANCH_NAME
// 				copyArtifacts(projectName: '${JOB_NAME}', selector: specific( buildNumber: '${BUILD_NUMBER}'));
// 				unzip zipFile: 'Vodovoz.zip', dir: OUTPUT_PATH
// 			}else{
// 				echo "Nothing to deploy"
// 			}
// 		}
// 	}
// }