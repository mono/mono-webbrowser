noinst_DATA = browser.exe

DIST_SOURCES = browser.cs

simple_sources_in=
simple_generated_sources=$(simple_sources_in:.in=)
simple_build_sources = $(addprefix $(srcdir)/, $(DIST_SOURCES))
simple_build_sources += $(simple_generated_sources)

browser.exe: $(simple_build_sources)
	$(MCS) -debug -target:winexe -out:$@ -pkg:dotnet $(simple_build_sources)

CLEANFILES = browser.exe browser.exe.mdb

DISTCLEANFILES = *.pidb $simple_sources_in

MAINTAINERCLEANFILES = Makefile.in
