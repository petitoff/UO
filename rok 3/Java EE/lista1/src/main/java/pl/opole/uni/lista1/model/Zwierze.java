package pl.opole.uni.lista1.model;

import jakarta.persistence.Id;
import jakarta.persistence.MappedSuperclass;

import java.util.Objects;

@MappedSuperclass
public class Zwierze {

    @Id
    private Integer id;
    private  String kontynent;
    private Integer ilosc_konczyn;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getKontynent() {
        return kontynent;
    }

    public void setKontynent(String kontynent) {
        this.kontynent = kontynent;
    }

    public Integer getIlosc_konczyn() {
        return ilosc_konczyn;
    }

    public void setIlosc_konczyn(Integer ilosc_konczyn) {
        this.ilosc_konczyn = ilosc_konczyn;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Zwierze zwierze = (Zwierze) o;
        return Objects.equals(id, zwierze.id);
    }

    @Override
    public int hashCode() {
        return Objects.hash(id);
    }
}
