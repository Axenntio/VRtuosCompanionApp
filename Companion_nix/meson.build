project(
	'VRtuos Companion',
	'cpp',
	version : '0.1',
	default_options : [
		'warning_level=3',
		'cpp_std=c++11'
	]
)

qt5 = import('qt5')
qt5dep = dependency('qt5', modules: ['Core', 'Gui', 'Widgets'])
system = build_machine.system()
if system == 'darwin'
	# Prepare for macOS
	soundDependancies = [
		dependency('appleframeworks', modules : 'CoreMIDI'),
		dependency('appleframeworks', modules : 'CoreAudio'),
		dependency('appleframeworks', modules : 'CoreFoundation')
	]
	defines='-D__MACOSX_CORE__'
elif system == 'linux'
	# Prepare for Linux
	soundDependancies = [
		dependency('alsa'),
		dependency('threads')
	]
	defines='-D__LINUX_ALSA__'
else
	error('Unknow build system ' + system)
endif



executable(
	'VRtuosCompanion',
	[
		qt5.preprocess(
			qresources : 'resources.qrc',
			ui_files: 'ui/ConnectForm.ui',
			moc_headers : 'inc/ConnectForm.hh'
		),
		'src/main.cpp',
		'src/RtMidi.cpp',
		'src/ConnectForm.cpp'
	],
	dependencies : [
		qt5dep,
		soundDependancies
	],
	cpp_args : defines
)